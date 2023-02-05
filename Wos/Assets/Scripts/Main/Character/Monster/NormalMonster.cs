using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Character_Movement, IBattle
{
    public DamageZone myDamageZone;
    public Monster_Data myData;
    public Collider myAI;
    public GameObject[] DropItems;
    public GameObject myIcon;
    public Transform myManager; // 매니저에게 값을 받음

    public Transform[] Roaming_Zone; // 0=U 1=D 2=R 3=L // 매니저에게 값을 받음
    Vector3 Roaming_Pos = Vector3.zero;

    public Transform HpZone;
    public GameObject myHpBar;
    HpBar_Monster myHpBar_clone = null;
    Transform myTarget = null;

    //for Dead
    float DownSpeed = 0.05f; // 죽고나서 내려가는 속도
    float DeadTime = 15.0f; // 죽고나서 부활되기까지 걸리는 시간

    public enum STATE
    {
        Create, Idle, Roaming, Battle, Dead, Resurrection
    }

    public STATE myState = STATE.Create;

    void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case STATE.Create:
                break;
            case STATE.Idle:
                if(myHpBar_clone != null)
                {
                    myHpBar_clone.gameObject.SetActive(false);
                }
                StartCoroutine(DelayRoaming(2.0f));
                break;
            case STATE.Roaming:
                Roaming_Pos.x = Random.Range(Roaming_Zone[2].position.x, Roaming_Zone[3].position.x);
                Roaming_Pos.z = Random.Range(Roaming_Zone[0].position.z, Roaming_Zone[1].position.z);
                Roaming_Pos.y = 0.5f;
                base.MoveToPos(Roaming_Pos, () => ChangeState(STATE.Idle));
                break;
            case STATE.Battle:
                AttackTarget(myTarget, AttackRange, myData.Ad);
                GameObject hpbar = Instantiate(myHpBar, Dont_Destroy_Data.Inst.Battle_Window) as GameObject;
                myHpBar_clone = hpbar.GetComponent<HpBar_Monster>();
                myHpBar_clone.myHpZone = HpZone;
                myHpBar_clone.StartSetting(this);
                break;
            case STATE.Dead:
                StopAllCoroutines();

                myAnim.SetBool("Dead", true);
                myHpBar_clone.gameObject.SetActive(false);
                // 퀘스트에 접근하여 연관된 퀘스트가 있는지 검사
                Check_Quest();
                // AI_Perception 끄기
                myAI.enabled = false;

                // 리지드바디 키네메틱 켜기
                myRigid.isKinematic = true;
                // 미니맵 아이콘 비활성화
                myIcon.SetActive(false);
                // 아이템 드랍
                OnDropItem();
                // 헌팅카운트 적용
                Plus_HuntingCount();
                // AI_Perception Target 초기화 + 콜라이더 끄기
                myAI.GetComponent<AI_Perception>().myTarget = null;
                myColl.enabled = false;
                break;
            case STATE.Resurrection:
                // 몬스터의 위치가 랜덤한 곳으로 전송됨
                RandomPos();
                // AI_Perception 켜기
                myAI.enabled = true;
                // 콜라이더 켜기
                myColl.enabled = true;
                // 리지드바디 키네메틱 끄기
                myRigid.isKinematic = false;
                // 미니맵 아이콘 활성화
                myIcon.SetActive(true);
                // 아이들 상태(애니)로 변경
                myAnim.SetBool("Dead", false);

                ChangeState(STATE.Idle);
                break;
        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case STATE.Create:
                break;
            case STATE.Idle:
                break;
            case STATE.Roaming:
                break;
            case STATE.Battle:
                break;
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

    IEnumerator DelayRoaming(float t)
    {
        yield return new WaitForSeconds(t);
        ChangeState(STATE.Roaming);
    }

    void Start()
    {
        ChangeState(STATE.Idle);
    }

    void Update()
    {
        StateProcess();
    }

    public void FindTarget(Transform target)
    {
        myTarget = target;
        StopAllCoroutines();
        ChangeState(STATE.Battle);
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

    public void AttackTarget()
    {
        myTarget.GetComponent<IBattle>()?.OnDamage(myData.Ap); // 공격력 전달
    }

    public void OnDamage(float dmg)
    {
        if (myState != STATE.Dead)
        {
            myAnim.SetTrigger("Damage");
            myDamageZone.OnDamage(dmg);
            myHpBar_clone.GetComponent<HpBar_Monster>().OnDmage(dmg);
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

    public virtual void RandomPos() { }
    public virtual void Check_Quest() { }
}
