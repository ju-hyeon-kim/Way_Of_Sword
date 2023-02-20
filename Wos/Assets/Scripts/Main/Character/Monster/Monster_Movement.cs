using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Movement : Character_Movement, IBattle
{
    public DamageText_Zone DamageText_Zone;
    public Collider myAI;
    public GameObject[] DropItems;
    public GameObject myIcon;
    public Transform myManager; // 매니저에게 값을 받음
    public Transform[] Roaming_Zone; // 0=U 1=D 2=R 3=L // 매니저에게 값을 받음
    Vector3 Roaming_Pos = Vector3.zero;
    public Transform HpZone;

    protected Transform myTarget = null;

    //for Dead
    float DownSpeed = 0.05f; // 죽고나서 내려가는 속도
    float DeadTime = 15.0f; // 죽고나서 부활되기까지 걸리는 시간

    public enum STATE
    {
        Create, Idle, Roaming, Appear, Battle, Dead, Resurrection
    }

    public STATE myState = STATE.Create;

    public  void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case STATE.Create:
                break;
            case STATE.Idle:
                Ready_Roaming();
                break;
            case STATE.Roaming: //nomal monster만 사용
                Roaming_Pos.x = Random.Range(Roaming_Zone[2].position.x, Roaming_Zone[3].position.x);
                Roaming_Pos.z = Random.Range(Roaming_Zone[0].position.z, Roaming_Zone[1].position.z);
                Roaming_Pos.y = 0.5f;
                base.MoveToPos(Roaming_Pos, () => ChangeState(STATE.Idle));
                break;
            case STATE.Appear: //boss monster만 사용
                myAnim.SetTrigger("Howl");
                break;
            case STATE.Battle:
                AttackTarget(myTarget, myStat.arange(), myStat.aspeed());
                Active_HpBar(true);
                break;
            case STATE.Dead:
                StopAllCoroutines();
                GiveXp_toPlayer();
                //HpBar 비활성화
                Active_HpBar(false);
                // 퀘스트에 접근하여 연관된 퀘스트가 있는지 검사
                Check_Quest();
                Dead_Or_Resurrection(false);
                // 아이템 드랍
                OnDropItem();
                // 헌팅카운트 적용
                Plus_HuntingCount();
                // AI_Perception Target 초기화 + 콜라이더 끄기
                myAI.GetComponent<AI_Perception>().myTarget = null;
                break;
            case STATE.Resurrection:
                // 체력바 초기화
                ResetHp();
                // 몬스터의 위치가 랜덤한 곳으로 전송됨
                RandomPos();
                Dead_Or_Resurrection(true);
                ChangeState(STATE.Idle);
                break;
        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case STATE.Dead:
                if (DeadTime > 0)
                {
                    DeadTime -= Time.deltaTime;
                    transform.Translate(Vector3.down * (Time.deltaTime * DownSpeed));
                }
                else
                {
                    DeadTime = 15.0f;
                    ChangeState(STATE.Resurrection);
                }
                break;
        }
    }

    void Start()
    {
        ChangeState(STATE.Idle);
    }

    void Update()
    {
        StateProcess();
    }

    public void LostTarget()
    {
        myTarget = null;
        StopAllCoroutines();
        if (myState != STATE.Dead)
        {
            myAnim.SetBool("Move", false);
            ChangeState(STATE.Idle);
        }
    }

    public void Attack_AnimEvent()
    {
        myTarget.GetComponent<IBattle>()?.OnDamage(myStat.ap()); // 공격력 전달
    }

    public void OnDamage(float dmg)
    {
        if (myState != STATE.Dead)
        {
            myAnim.SetTrigger("Damage");
            DamageText_Zone.OnDamage(dmg, false);
            Ondamge_HpBar(dmg);
        }
    }

    public void OnDead()
    {
        ChangeState(STATE.Dead);
    }

    public void OnDropItem()
    {
        for (int i = 0; i < DropItems.Length; i++)
        {
            GameObject dropitem = Instantiate(DropItems[i], this.transform.root) as GameObject;

            //아이템들끼리 서로 다른곳에 드랍되게 하기위함
            Vector3 pos = new Vector3(0, 1, i);
            dropitem.transform.position = this.transform.position + pos;

            dropitem.GetComponent<Item_3D>().OnDrop();
        }
    }

    void Plus_HuntingCount()
    {
        BossEmergence BE = Dont_Destroy_Data.Inst.Battle_Window.GetComponent<Battle_Window>().BossEmergence;
        BE.Plus_Hunting_Count();
    }

    void Dead_Or_Resurrection(bool b) //Dead = false, Resurrection = true
    {
        // 애니메이션
        myAnim.SetBool("Dead", !b);
        // AI_Perception
        myAI.enabled = b;
        // 리지드바디 키네메틱
        myRigid.isKinematic = !b;
        // 콜라이더
        myColl.enabled = b;
        // 미니맵 아이콘
        myIcon.SetActive(b);
    }

    protected void AttackTarget(Transform target, float AttackRange, float AttackDelay)
    {
        StopAllCoroutines();
        StartCoroutine(Attacking(target, AttackRange, AttackDelay));
    }

    IEnumerator Attacking(Transform target, float AttackRange, float AttackDelay) //몬스터만 사용
    {
        float playTime = AttackDelay; // 처음에 바로 공격
        float delta = 0.0f;

        while (target != null)
        {
            if (!myAnim.GetBool("isAttacking")) playTime += Time.deltaTime;
            //이동
            Vector3 dir = target.position - transform.position;
            float dist = dir.magnitude;
            dir.Normalize();
            if (dist > AttackRange)
            {
                myAnim.SetBool("Move", true);
                delta = myStat.mspeed() * Time.deltaTime;
                if (delta > dist)
                {
                    delta = dist;
                }
                transform.Translate(dir * delta, Space.World);
            }
            else
            {
                myAnim.SetBool("Move", false);
                if (playTime >= AttackDelay)
                {
                    //공격
                    playTime = 0.0f;
                    myAnim.SetTrigger("Attack");
                }
            }

            //회전
            delta = RotSpeed * Time.deltaTime;
            float Angle = Vector3.Angle(dir, transform.forward);
            float rotDir = 1.0f;
            if (Vector3.Dot(transform.right, dir) < 0.0f)
            {
                rotDir = -rotDir;
            }
            if (delta > Angle)
            {
                delta = Angle;
            }
            transform.Rotate(Vector3.up * delta * rotDir, Space.World);

            if(target.GetComponent<Player>().nowMode == Mode.DEAD) // 플레이어가 죽었다면
            {
                target = null;
                ChangeState(STATE.Roaming);
            }

            yield return null;
        }
        myAnim.SetBool("Move", false);
    }

    void GiveXp_toPlayer()
    {
        myTarget.GetComponent<Player>().Get_XP(myStat.xp());
    }

    public virtual void FindTarget(Transform target) { }
    public virtual void Ready_Roaming() { }
    public virtual void Active_HpBar(bool b) { }
    public virtual void Ondamge_HpBar(float dmg) { }
    public virtual void RandomPos() { }
    public virtual void Check_Quest() { }
    public virtual void ResetHp() { }
}