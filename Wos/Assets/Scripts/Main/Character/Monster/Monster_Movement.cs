using System.Collections;
using System.Collections.Generic;
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
    public Manager_Dungeon myManager; // �Ŵ������� ���� ����
    public Transform[] Roaming_Zone; // 0=U 1=D 2=R 3=L // �Ŵ������� ���� ����
    public Transform HpZone;
    public MonstertState myState = MonstertState.Create;

    protected Transform myTarget = null;
    Vector3 Roaming_Pos = Vector3.zero;

    //for Dead
    float DownSpeed = 0.05f; // �װ��� �������� �ӵ�
    float DeadTime = 15.0f; // �װ��� ��Ȱ�Ǳ���� �ɸ��� �ð�

    public  void ChangeState(MonstertState s)
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
            case MonstertState.Roaming: //nomal monster�� ���


                Roaming_Pos.x = Random.Range(Roaming_Zone[2].position.x, Roaming_Zone[3].position.x);
                Roaming_Pos.z = Random.Range(Roaming_Zone[0].position.z, Roaming_Zone[1].position.z);
                Roaming_Pos.y = 0.5f;
                base.MoveToPos(Roaming_Pos, () => ChangeState(MonstertState.Idle));
                break;
            case MonstertState.Appear: //boss monster�� ���
                myAnim.SetTrigger("Howl");
                break;
            case MonstertState.Battle:
                AttackTarget(myTarget, myStat.arange(), myStat.aspeed());
                Active_HpBar(true);
                break;
            case MonstertState.Dead:
                StopAllCoroutines();

                GiveXp_toPlayer();
                //HpBar ��Ȱ��ȭ
                Active_HpBar(false);
                // ����Ʈ�� �����Ͽ� ������ ����Ʈ�� �ִ��� �˻�
                Check_Quest();
                Dead_Or_Resurrection(false);
                // ������ ���
                OnDropItem();
                // ����ī��Ʈ ����
                Plus_HuntingCount();
                // AI_Perception Target �ʱ�ȭ + �ݶ��̴� ����
                myAI.GetComponent<AI_Perception>().myTarget = null;
                break;
            case MonstertState.Resurrection:
                // ü�¹� �ʱ�ȭ
                ResetHp();
                // ������ ��ġ�� ������ ������ ���۵�
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
            case MonstertState.Dead:
                if (DeadTime > 0)
                {
                    DeadTime -= Time.deltaTime;
                    transform.Translate(Vector3.down * (Time.deltaTime * DownSpeed));
                }
                else
                {
                    DeadTime = 15.0f;
                    ChangeState(MonstertState.Resurrection);
                }
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
        myTarget.GetComponent<IBattle>()?.OnDamage(myStat.ap()); // ���ݷ� ����
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

    public void OnDead()
    {
        ChangeState(MonstertState.Dead);
    }

    public void OnDropItem()
    {
        for (int i = 0; i < DropItems.Length; i++)
        {
            GameObject dropitem = Instantiate(DropItems[i], this.transform.root) as GameObject;

            //�����۵鳢�� ���� �ٸ����� ����ǰ� �ϱ�����
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
        // �ִϸ��̼�
        myAnim.SetBool("Dead", !b);
        // AI_Perception
        myAI.enabled = b;
        // ������ٵ� Ű�׸�ƽ
        myRigid.isKinematic = !b;
        // �ݶ��̴�
        myColl.enabled = b;
        // �̴ϸ� ������
        myIcon.SetActive(b);
    }

    protected void AttackTarget(Transform target, float AttackRange, float AttackDelay)
    {
        StopAllCoroutines();
        StartCoroutine(Attacking(target, AttackRange, AttackDelay));
    }

    IEnumerator Attacking(Transform target, float AttackRange, float AttackDelay) //���͸� ���
    {
        float playTime = AttackDelay; // ó���� �ٷ� ����
        float delta = 0.0f;

        while (target != null)
        {
            if (!myAnim.GetBool("isAttacking")) playTime += Time.deltaTime;
            //�̵�
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
                    //����
                    playTime = 0.0f;
                    myAnim.SetTrigger("Attack");
                }
            }

            //ȸ��
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

            if(target.GetComponent<Player>().nowMode == Mode.DEAD) // �÷��̾ �׾��ٸ�
            {
                target = null;
                if(TryGetComponent<NormalMonster>(out NormalMonster component)) // �븻������ ���
                {
                    ChangeState(MonstertState.Roaming);
                }
                else // ���������� ���
                {
                    // �Ͽ︵
                }
            }

            yield return null;
        }
        myAnim.SetBool("Move", false);
    }

    void GiveXp_toPlayer()
    {
        myTarget.GetComponent<Player>().Get_XP(myStat.xp());
        Dont_Destroy_Data.Inst.Message_Window.Get_Xp((int)myStat.xp());
    }
    public virtual void FindTarget(Transform target) { }
    public virtual void Ready_Roaming() { }
    public virtual void Active_HpBar(bool b) { }
    public virtual void Ondamge_HpBar(float dmg) { }
    public virtual void RandomPos() { }
    public virtual void Check_Quest() { }
    public virtual void ResetHp() { }
}