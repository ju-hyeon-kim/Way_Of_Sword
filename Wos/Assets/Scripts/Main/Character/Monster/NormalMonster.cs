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
    public Transform myManager; // �Ŵ������� ���� ����

    public Transform[] Roaming_Zone; // 0=U 1=D 2=R 3=L // �Ŵ������� ���� ����
    Vector3 Roaming_Pos = Vector3.zero;

    public Transform HpZone;
    public GameObject myHpBar;
    HpBar_Monster myHpBar_clone = null;
    Transform myTarget = null;

    //for Dead
    float DownSpeed = 0.05f; // �װ��� �������� �ӵ�
    float DeadTime = 15.0f; // �װ��� ��Ȱ�Ǳ���� �ɸ��� �ð�

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
                // ����Ʈ�� �����Ͽ� ������ ����Ʈ�� �ִ��� �˻�
                Check_Quest();
                // AI_Perception ����
                myAI.enabled = false;

                // ������ٵ� Ű�׸�ƽ �ѱ�
                myRigid.isKinematic = true;
                // �̴ϸ� ������ ��Ȱ��ȭ
                myIcon.SetActive(false);
                // ������ ���
                OnDropItem();
                // ����ī��Ʈ ����
                Plus_HuntingCount();
                // AI_Perception Target �ʱ�ȭ + �ݶ��̴� ����
                myAI.GetComponent<AI_Perception>().myTarget = null;
                myColl.enabled = false;
                break;
            case STATE.Resurrection:
                // ������ ��ġ�� ������ ������ ���۵�
                RandomPos();
                // AI_Perception �ѱ�
                myAI.enabled = true;
                // �ݶ��̴� �ѱ�
                myColl.enabled = true;
                // ������ٵ� Ű�׸�ƽ ����
                myRigid.isKinematic = false;
                // �̴ϸ� ������ Ȱ��ȭ
                myIcon.SetActive(true);
                // ���̵� ����(�ִ�)�� ����
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
        myTarget.GetComponent<IBattle>()?.OnDamage(myData.Ap); // ���ݷ� ����
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

            //�����۵鳢�� ���� �ٸ����� ����ǰ� �ϱ�����
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
