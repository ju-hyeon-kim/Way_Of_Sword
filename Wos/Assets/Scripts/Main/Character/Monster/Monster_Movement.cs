using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Movement : Character_Movement, IBattle
{
    public DamageText_Zone DamageText_Zone;
    public Monster_Data myData;
    public Collider myAI;
    public GameObject[] DropItems;
    public GameObject myIcon;
    public Transform myManager; // �Ŵ������� ���� ����
    public Transform[] Roaming_Zone; // 0=U 1=D 2=R 3=L // �Ŵ������� ���� ����
    Vector3 Roaming_Pos = Vector3.zero;
    public Transform HpZone;

    protected Transform myTarget = null;

    //for Dead
    float DownSpeed = 0.05f; // �װ��� �������� �ӵ�
    float DeadTime = 15.0f; // �װ��� ��Ȱ�Ǳ���� �ɸ��� �ð�

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
                Check_HpBar();
                break;
            case STATE.Roaming: //nomal monster�� ���

                Roaming_Pos.x = Random.Range(Roaming_Zone[2].position.x, Roaming_Zone[3].position.x);
                Roaming_Pos.z = Random.Range(Roaming_Zone[0].position.z, Roaming_Zone[1].position.z);
                Roaming_Pos.y = 0.5f;
                base.MoveToPos(Roaming_Pos, () => ChangeState(STATE.Idle));
                break;
            case STATE.Appear: //boss monster�� ���
                myAnim.SetTrigger("Howl");
                break;
            case STATE.Battle:
                AttackTarget(myTarget, AttackRange, myData.Ad);
                Conect_HpBar();
                break;
            case STATE.Dead:
                StopAllCoroutines();

                Unactive_HpBar();
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
            case STATE.Resurrection:
                // ������ ��ġ�� ������ ������ ���۵�
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

    public void AttackTarget()
    {
        myTarget.GetComponent<IBattle>()?.OnDamage(myData.Ap); // ���ݷ� ����
    }

    public void OnDamage(float dmg)
    {
        if (myState != STATE.Dead)
        {
            myAnim.SetTrigger("Damage");
            DamageText_Zone.OnDamage(dmg);
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
        StartCoroutine(AttackingPlayer(target, AttackRange, AttackDelay));
    }

    IEnumerator AttackingPlayer(Transform target, float AttackRange, float AttackDelay) //���͸� ���
    {
        float playTime = 0.0f;
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
                delta = MoveSpeed * Time.deltaTime;
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

            yield return null;
        }
        myAnim.SetBool("Move", false);
    }

    public virtual void FindTarget(Transform target) { }
    public virtual void Check_HpBar() { }
    public virtual void Conect_HpBar() { }
    public virtual void Ondamge_HpBar(float dmg) { }
    public virtual void Unactive_HpBar() { }
    public virtual void RandomPos() { }
    public virtual void Check_Quest() { }
}