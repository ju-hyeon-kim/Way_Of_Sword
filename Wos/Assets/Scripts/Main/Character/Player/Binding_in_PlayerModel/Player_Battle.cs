using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player_Battle : Player_Movement, IBattle
{
    [Header("-----Player_Battle-----")]
    public Manager_Skill Manager_Skill;
    public DropRange DropRange;
    
    public float Ap = 10;
    Transform myTarget;
    bool isComboable = false;
    Vector3 EffectPos = Vector3.zero;
    int SkillNum = 0;
    int ClickCount = 0;
    bool isSkilling = true;


    public override void Click_MouseLeftButton()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000.0f, TargetMask))
        {
            isJustMove = true;
            //���͸� Ŭ���� ��� -> ���Ϳ��� �̵� �� �޺�����
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster") && !myAnim.GetBool("isAttacking"))
            {
                myTarget = hit.collider.transform;
                if(Manager_Skill.GetRangeActive()) // Skill Range�� �������� ��� �⺻ ���� �Ұ�
                {
                    base.MoveToPos(hit.point, () => GetComponent<Animator>().SetTrigger("ComboAttack"));
                }
            }
            //Npc�� Ŭ���� ��� -> Npc���� �̵�
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Npc"))
            {
                MoveToNpc(hit);
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

    public void OnDamage(float dmg)
    {
        if (myAnim.GetBool("isIdle")) // �����߿��� Damage �ִ� �۵��Ұ�, ��, ü���� ����
        {
            myAnim.SetTrigger("Damage");
        }

    }

    public void Hit_Target()
    {
        Transform Weapon_Hand = GetComponent<Player>().Parents_of_Weapon[1];
        Collider[] list = Physics.OverlapSphere(Weapon_Hand.GetChild(1).position, 1f, 1 << LayerMask.NameToLayer("Monster"));

        foreach (Collider col in list)
        {
            col.GetComponent<Monster_Movement>().OnDamage(Ap);
        }
    }

    public override bool Get_isComboable() { return isComboable; }

    public override void Rot_inComboAttak()
    {
        ++ClickCount;
        base.MoveToPos(myTarget.position, null, false, true);
    }

    #region for Skill
    public override void OnSkillRange(int i)
    {
        Manager_Skill.OnSkillRange(i);
        StartCoroutine(Skilling(i));
    }

    IEnumerator Skilling(int i)
    {
        isSkilling = true;
        while (isSkilling)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f,1 << LayerMask.NameToLayer("SkillRange"))) // ���콺 �������� SkillRange�� ����������
            {
                Manager_Skill.MouseOnSkillRange(i, hit.point);

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
                Manager_Skill.UnActive_Point(i);
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
        Manager_Skill.UnActive_RangeAndPoint(i);
        isSkilling = false;
    }

    public void ChangeMP()
    {

    }

    IEnumerator SkillCool()
    {
        yield return null;
    }

    public void OnSkillEffct()
    {
        Manager_Skill.OnSkillEffect(SkillNum, EffectPos);
    }
    #endregion

    #region for Npc
    public virtual void MoveToNpc(RaycastHit hit) { }
    #endregion

    #region for ItmeDrop
    public override void Pickup_Item()
    {
        DropRange.Pickup_Item();
    }
    #endregion
}