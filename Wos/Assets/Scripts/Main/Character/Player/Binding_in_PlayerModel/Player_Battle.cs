using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player_Battle : Player_Movement, IBattle
{
    [Header("-----Player_Battle-----")]
    public Player_Interface myInterface;
    public DamageText_Zone DamageText_Zone;
    public DropRange DropRange;
    public Transform ComboAttack_Point;

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
                if(!myInterface.GetRangeActive()) // Skill Range�� �������� ��츸 �⺻ ���� ����
                {

                    base.MoveToPos(hit.point, () => GetComponent<Animator>().SetTrigger("ComboAttack"));
                }
            }
            //Npc�� Ŭ���� ��� -> Npc���� �̵� �� ���ɱ�
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Npc"))
            {
                myTarget = hit.collider.transform;
                isNpc = true;
                base.MoveToPos(hit.point);
            }
        }
    }

    public override void ComboCheck(bool b)
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

    public void OnDamage(float dmg) // ib
    {
        DamageText_Zone.OnDamage(dmg, true);

        if (myAnim.GetBool("isIdle")) // �����߿��� Damage �ִ� �۵��Ұ�, ��, ü���� ����
        {
            myAnim.SetTrigger("Damage");
        }

        myInterface.OnDamage(dmg);
    }

    public void Hit_Attack()
    {
        float radius = 1.3f;
        Collider[] list = Physics.OverlapSphere(ComboAttack_Point.position, radius, 1 << LayerMask.NameToLayer("Monster"));

        foreach (Collider col in list)
        {
            col.GetComponent<Monster_Movement>().OnDamage( myStat.ap() );
        }
    }

    public override bool Get_isComboable() { return isComboable; }

    public override void Rot_inComboAttak()
    {
        ++ClickCount;
        base.MoveToPos(myTarget.position, null, false, true);
    }

    public void Get_XP(float xp)
    {
        myInterface.Get_Xp(xp);
    }

    #region for Skill
    public override void OnSkillRange(int i)
    {
        if(GetComponent<Player>().nowMode == Mode.BATTLE) // ��Ʋ�����
        {
            if (myInterface.isPossibeSkill(i, myStat.curmp())) // ��Ÿ���� �ƴϰ� ��� ������ ������ ���� ���
            {
                myInterface.OnSkillRange(i);
                StartCoroutine(Skilling(i));
            }
        }
    }

    IEnumerator Skilling(int i)
    {
        isSkilling = true;
        while (isSkilling)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f,1 << LayerMask.NameToLayer("SkillRange"))) // ���콺 �������� SkillRange�� ����������
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
                    myAnim.SetTrigger("Qskill");

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
}