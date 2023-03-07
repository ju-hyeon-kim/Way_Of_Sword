using System.Collections;
using UnityEngine;

public enum MonstertState
{
    Create, Idle, Roaming, Appear, Battle, Dead, Resurrection
}

public class Monster_Movement : Character_Movement, IBattle
{
    [Header("-----Monster_Movement-----")]
    public DamageText_Zone DamageText_Zone;
    public Collider myAI;
    public GameObject[] DropItems;
    public GameObject myIcon;
    public Transform[] Roaming_Zone; // 0=U 1=D 2=R 3=L // 매니저에게 값을 받음
    public MonstertState myState = MonstertState.Create;
    [HideInInspector]
    public Manager_Dungeon myManager; // 매니저에게 값을 받음

    protected Transform myTarget = null;
    protected Coroutine CoAttack = null;
    Vector3 Roaming_Pos = Vector3.zero;

    //for Dead
    public float DownSpeed = 0f; // 죽고나서 내려가는 속도: 노말몬스터->0.05f / 노말몬스터->0.1f
    protected float DeadTime = 15.0f; // 죽고나서 부활되기까지 걸리는 시간

    public void ChangeState(MonstertState s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case MonstertState.Create:
                break;
            case MonstertState.Idle:
                Ready_Roaming();
                break;
            case MonstertState.Roaming: //nomal monster만 사용
                Roaming_Pos.x = Random.Range(Roaming_Zone[2].position.x, Roaming_Zone[3].position.x);
                Roaming_Pos.z = Random.Range(Roaming_Zone[0].position.z, Roaming_Zone[1].position.z);
                Roaming_Pos.y = 0.5f;
                base.MoveToPos(Roaming_Pos, () => ChangeState(MonstertState.Idle));
                break;
            case MonstertState.Appear: //boss monster만 사용
                myAnim.SetTrigger("Howl");
                break;
            case MonstertState.Battle:
                AttackTarget(myTarget, myStat.arange(), myStat.aspeed());
                Active_HpBar(true);
                break;
            case MonstertState.Dead:
                Debug.Log("Dead스테이트 발동");

                StopAllCoroutines();
                // BossMonster.cs 에서 재정의
                BossDead(); 
                // 플레이어에게 경험치주기
                GiveXp_toPlayer();
                // HpBar 비활성화
                Active_HpBar(false);
                // 퀘스트에 접근하여 연관된 퀘스트가 있는지 검사
                Check_Quest();
                //죽음 또는 소생 함수
                Dead_Or_Resurrection(false);
                // 아이템 드랍
                OnDropItem();
                // 헌팅카운트 적용
                Plus_HuntingCount();
                // AI_Perception Target 초기화 + 콜라이더 끄기
                myAI.GetComponent<AI_Perception>().myTarget = null;
                break;
            case MonstertState.Resurrection:
                // 체력바 초기화
                ResetHp();
                // 몬스터의 위치가 랜덤한 곳으로 전송됨
                RandomPos();
                Dead_Or_Resurrection(true);
                ChangeState(MonstertState.Idle);
                break;
        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case MonstertState.Dead: // 추상화되어있는 CorpseDown()가 매 프레임마다 실행됨 -> 자식에 따라 재정의 -> 노말몬스터 소생o / 보스몬스터는 소생x
                CorpseDown();

                
                break;
        }
    }

    void Start()
    {
        ChangeState(MonstertState.Idle);
    }

    void Update()
    {
        StateProcess();
    }

    public void LostTarget()
    {
        myTarget = null;
        StopAllCoroutines();
        if (myState != MonstertState.Dead)
        {
            myAnim.SetBool("Move", false);
            ChangeState(MonstertState.Idle);
        }
    }

    public void Attack_AnimEvent()
    {
        myTarget.GetComponent<IBattle>()?.OnDamage(myStat.ap()); // 공격력 전달
    }

    public void OnDamage(float dmg)
    {
        if (myState != MonstertState.Dead)
        {
            myAnim.SetTrigger("Damage");
            DamageText_Zone.OnDamage(dmg, false, myManager.BattleWindow_ofMonster);
            Ondamge_HpBar(dmg);
        }
    }

    public void OnDropItem()
    {
        for (int i = 0; i < DropItems.Length; i++)
        {
            GameObject dropitem = Instantiate(DropItems[i], this.transform.root) as GameObject;

            //아이템들끼리 서로 다른곳에 드랍되게 하기위함
            Vector3 pos = new Vector3(0, 1, i);
            dropitem.transform.position = this.transform.position + pos;

            dropitem.GetComponent<Item_3D>().OnDrop(myManager.Unactive_Area);
        }
    }

    void Plus_HuntingCount()
    {
        BossEmergence BE = myManager.BossEmergence;
        BE.Plus_Hunting_Count();
    }

    void Dead_Or_Resurrection(bool b) //Dead = false, Resurrection = true
    {
        Debug.Log("Dead_Or_Resurrection함수 발동");
        // 애니메이션
        if (!b) myAnim.SetTrigger("Dead");
        else myAnim.SetTrigger("Resurrection"); //노말 몬스터만 사용
        // AI_Perception
        myAI.enabled = b;
        // 리지드바디 키네메틱 -> false -> 땅으로 내려감
        myRigid.isKinematic = !b;
        // 콜라이더
        myColl.enabled = b;
        // 미니맵 아이콘
        myIcon.SetActive(b);
    }

    protected void AttackTarget(Transform target, float AttackRange, float AttackDelay)
    {
        StopAllCoroutines();
        CoAttack = StartCoroutine(Attacking(target, AttackRange, AttackDelay));
    }

    IEnumerator Attacking(Transform target, float AttackRange, float AttackDelay) //몬스터만 사용
    {
        float playTime = AttackDelay; // 처음에 바로 공격
        float delta = 0.0f;

        while (target != null)
        {
            if (!myAnim.GetBool("isAttacking")) playTime += Time.deltaTime;

            // 이동
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
                    // 공격
                    playTime = 0.0f;
                    myAnim.SetTrigger("Attack");
                    BossAction();
                }
            }

            // 회전
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

            if (target.GetComponent<Player>().nowMode == Mode.DEAD) // 플레이어가 죽었다면
            {
                target = null;
                if (TryGetComponent<NormalMonster>(out NormalMonster component)) // 노말몬스터일 경우
                {
                    ChangeState(MonstertState.Roaming);
                }
                else // 보스몬스터일 경우
                {
                    // 하울링
                }
            }
            yield return null;
        }
        myAnim.SetBool("Move", false);
    }

    void GiveXp_toPlayer()
    {
        myTarget.GetComponent<Player>().Get_XP(myStat.xp());
        Dont_Destroy_Data.Inst.ItemAcuisition_Message.Get_Xp((int)myStat.xp());
    }

    public override float myAttackRange()
    {
        return myStat.arange();
    }

    public virtual void FindTarget(Transform target) { }
    public virtual void Ready_Roaming() { }
    public virtual void Active_HpBar(bool b) { }
    public virtual void Ondamge_HpBar(float dmg) { }
    public virtual void RandomPos() { }
    public virtual void Check_Quest() { }
    public virtual void ResetHp() { }
    public virtual void BossAction() { }
    public virtual void BossDead() { }
    public virtual void CorpseDown() { }
}