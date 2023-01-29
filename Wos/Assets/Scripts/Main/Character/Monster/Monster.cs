using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Monster_Movement, IBattle
{
    public Monster_Data myData;
    public Collider myAI;
    public GameObject[] DropItems;

    public Transform[] Roaming_Zone; // 0=U 1=D 2=R 3=L // 매니저에게 값을 받음
    Vector3 Roaming_Pos = Vector3.zero;

    public Transform HpZone;
    public GameObject myHpBar;
    HpBar_Monster myHpBar_clone;
    Transform myTarget = null;

    public enum STATE
    {
        Create, Idle, Roaming, Battle, Dead
    }

    public STATE myState = STATE.Create;

    void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;
        switch(myState)
        {
            case STATE.Create:
                break;
            case STATE.Idle:
                StartCoroutine(DelayRoaming(2.0f));
                break;
            case STATE.Roaming:
                Roaming_Pos.x = Random.Range(Roaming_Zone[2].position.x, Roaming_Zone[3].position.x);
                Roaming_Pos.z = Random.Range(Roaming_Zone[0].position.z, Roaming_Zone[1].position.z);
                Roaming_Pos.y = transform.position.y;
                base.MoveToPos(Roaming_Pos,() => ChangeState(STATE.Idle));
                break;
            case STATE.Battle:
                AttackTarget(myTarget, AttackRange, myData.Ad);
                GameObject hpbar = Instantiate(myHpBar, Dont_Destroy_Data.Inst.Battle_Window) as GameObject;
                myHpBar_clone = hpbar.GetComponent<HpBar_Monster>();
                myHpBar_clone.myHpZone = HpZone;
                myHpBar_clone.StartSetting(this);
                break;
            case STATE.Dead:
                // AI_Perception 꺼버리기
                myAI.enabled = false;

                StopAllCoroutines();
                myAnim.SetTrigger("Dead");
                myHpBar_clone.gameObject.SetActive(false);
                OnDropItem();
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
            myHpBar_clone.GetComponent<HpBar_Monster>().OnDmage(dmg);
        }
    }

    public void OnDead()
    {
        ChangeState(STATE.Dead);
    }

    public void OnDropItem()
    {
        for(int i = 0; i < DropItems.Length; i++)
        {
            GameObject dropitem = Instantiate(DropItems[i], this.transform.root) as GameObject;

            //아이템들끼리 서로 다른곳에 드랍되게 하기위함
            Vector3 pos = new Vector3(0,1,i);
            dropitem.transform.position = this.transform.position + pos;

            dropitem.GetComponent<Item_3D>().OnDrop();
        }
    }
}
