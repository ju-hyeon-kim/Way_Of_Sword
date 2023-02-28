using System.Collections;
using System.Linq;
using UnityEngine;

public class Player_Battle : Player_Movement, IBattle
{
    [Header("-----Player_Battle-----")]
    public Player_Interface myInterface;
    public DamageText_Zone DamageText_Zone;
    public DropRange DropRange;
    public Transform AttackRange;

    protected Transform myTarget; // Battle = monster, unBattle = Npc

    //for ComboAttack
    bool isComboable = false;
    int ClickCount = 0;

    //for Skill
    int SkillNum = 0;
    bool isSkilling = true;
    Vector3 EffectPos = Vector3.zero;

    public override void Click_MouseLeftButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000.0f, TargetMask))
        {
            //���͸� Ŭ���� ��� -> ���Ϳ��� �̵� �� �޺�����
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster") && !myAnim.GetBool("isAttacking"))
            {
                myTarget = hit.collider.transform;
                if (!myInterface.GetRangeActive()) // Skill Range�� �������� ��츸 �⺻ ���� ����
                {
                    base.MoveToPos(myTarget.position, () => GetComponent<Animator>().SetTrigger("ComboAttack"));
                }
            }
            //Npc�� Ŭ���� ��� -> Npc���� �̵� �� ���ɱ�
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Npc"))
            {
                myTarget = hit.collider.transform;
                base.MoveToPos(myTarget.position, () => Talk_toNPC());
            }
        }
    }

    public override void ComboCheck(bool b) // Anim Event
    {
        if (b)
        {
            isComboable = true;
            ClickCount = 0;
        }
        else
        {
            isComboable = false;
            if (ClickCount == 0)
            {
                myAnim.SetTrigger("ComboFail");
            }
        }
    }

    public void OnDamage(float dmg)
    {
        DamageText_Zone.OnDamage(dmg, true, Dont_Destroy_Data.Inst.BattleWindow_ofPlayer);
        if (myAnim.GetBool("isIdle")) // �����߿��� Damage �ִ� �۵��Ұ�, ��, ü���� ����
        {
            myAnim.SetTrigger("Damage");
        }
        myInterface.OnDamage(dmg);
    }

    public void Hit_Attack()
    {
        float radius = 1.5f;
        Collider[] list = Physics.OverlapSphere(AttackRange.position, radius, 1 << LayerMask.NameToLayer("Monster"));
        foreach (Collider col in list)
        {
            col.GetComponent<Monster_Movement>().OnDamage(myStat.ap());
        }
    }

    public override bool Get_isComboable() { return isComboable; }

    public override void Rot_inComboAttak()
    {
        ++ClickCount;
        base.MoveToPos(myTarget.position, null, false, true);
    }

    public override float myAttackRange() // ���� ó��: 
    {
        if (myTarget.GetComponent<Monster_Movement>() != null)
        {
            return myTarget.GetComponent<Monster_Movement>().myAttackRange(); // ������ ��� -> ������ ��Ÿ��� ��ȯ
        }
        return 2; // Npc�� ��� -> 3�� ��ȯ -> Npc�� 3�� �Ÿ���ŭ �ٰ����� �� ��ȣ�ۿ� �ߵ�
    }

    public void Get_XP(float xp)
    {
        myInterface.Get_Xp(xp);
    }

    #region for Skill
    public override void OnSkillRange(int i)
    {
        if (!myInterface.isEmpyhSlot(i)) //i�� �ش��ϴ� ��ų ���Կ� ��ų�� ����ִٸ�
        {
            if (GetComponent<Player>().nowMode == Mode.BATTLE) // ��Ʋ�����
            {
                if (myInterface.isPossibeSkill(i, myStat.curmp())) // ��Ÿ���� �ƴϰ� ��� ������ ������ ���� ���
                {
                    myInterface.OnSkillRange(i);
                    StartCoroutine(Skilling(i));
                }
            }
        }
    }

    IEnumerator Skilling(int i)
    {
        isSkilling = true;
        while (isSkilling)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("SkillRange"))) // ���콺 �������� SkillRange�� ����������
            {
                myInterface.MouseOnSkillRange(i, hit.point);

                if (Input.GetMouseButtonDown(0)) // ��Ŭ�� = ��ų�ߵ�
                {
                    //��ų����Ʈ ������ġ ����
                    EffectPos = hit.point;
                    SkillNum = i;

                    //�̵����̶�� �̵� ����
                    GetComponent<Player_Movement>().Stop_Movement();

                    //������ ��ų �ߵ�
                    base.MoveToPos(hit.point, null, false, true); // ȸ���� ����
                    switch (i)
                    {
                        case 0:
                            myAnim.SetTrigger("Qskill");
                            break;
                        case 1:
                            myAnim.SetTrigger("Wskill");
                            break;
                        case 2:
                            myAnim.SetTrigger("Eskill");
                            break;
                        case 3:
                            myAnim.SetTrigger("Rskill");
                            break;
                    }


                    StopSkilling(i);
                }
            }
            else // SkillRange�� ������ ���� ���� ��
            {
                myInterface.UnActive_Point(i);
            }

            if (Input.GetMouseButtonDown(1)) // SkillRanger�� Ȱ��ȭ�� ���¿��� ��Ŭ�� ���� �� = ��ų ���
            {
                StopSkilling(i);
            }
            yield return null;
        }
    }

    void StopSkilling(int i)
    {
        myInterface.UnActive_RangeAndPoint(i);
        isSkilling = false;
    }

    public void OnSkillEffct()
    {
        myInterface.OnSkillEffect(SkillNum, EffectPos); // ��ų�� ���ݷ��� ��� �����ñ�
    }
    #endregion

    #region for ItmeDrop
    public override void Pickup_Item()
    {
        DropRange.Pickup_Item();
    }
    #endregion

    #region for Npc
    void Talk_toNPC()
    {
        ControlPossible = false; // �÷��̾��� ���� ����
        myTarget.GetComponent<Npc>().Reaction(this.gameObject);
    }
    #endregion
}