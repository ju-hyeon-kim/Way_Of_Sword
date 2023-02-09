using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Battle : Player_Movement, IBattle
{
    [Header("-----Player_Battle-----")]
    public SkillRange SkillRange;
    public SkillPoints SkillPoints;
    public Skill_Set Skill_Set;
    public DropRange DropRange;
    
    public float Ap = 10;
    GameObject myEnemy;
    bool isComboable = false;
    int ClickCount = 0;
    GameObject SkillEffct;
    Vector3 EffectPos;
    

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
                myEnemy = hit.collider.gameObject;
                if(!SkillRange.gameObject.activeSelf) // Skill Range�� �������� ��� �⺻ ���� �Ұ�
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
        base.MoveToPos(myEnemy.transform.position, null, false, true);
    }

    public override void Pickup_Item()
    {
        DropRange.Pickup_Item();
    }

    public virtual void MoveToNpc(RaycastHit hit) { }

    #region for Skill
    public override void OnSkillRange(int i)
    {
        //SkillRange, SkillPoint data ��������
        Skill_Set.Slots[i].OnSkillRange(SkillRange, SkillPoints, i);
        SkillRange.gameObject.SetActive(true);

        StartCoroutine(Skilling(i));
    }

    IEnumerator Skilling(int i)
    {
        bool isSkilling = true;
        while (isSkilling)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f,1 << LayerMask.NameToLayer("SkillRange")))
            {
                SkillPoints.SP_OnOff(i, true);
                //��Ʈ �����ǿ� ���� ��ų����Ʈ�� �������� ������Ʈ
                SkillPoints.PosUpdating(i, hit.point);

                if(Input.GetMouseButtonDown(0)) // ��Ŭ�� = ��ų�ߵ�
                {
                    //������ ����Ʈ�� ����Ʈ�� ������ġ ����
                    SkillEffct = Skill_Set.Slots[i].nowSkill.Effect;
                    EffectPos = hit.point;

                    //SkillRange, SkillPoint unActive
                    SkillRange.gameObject.SetActive(false);
                    SkillPoints.SP_OnOff(i, false);

                    //������ ��ų �ߵ�
                    isJustMove = false;
                    Vector3 vec = hit.point - transform.position;
                    AttackRange = vec.magnitude;
                    base.MoveToPos(hit.point, () => GetComponent<Animator>().SetTrigger("Qskill"));
                }
            }
            else // SkillRange�� ������ ���� ���� ��
            {
                SkillPoints.SP_OnOff(i, false);
            }

            if (Input.GetMouseButtonDown(1)) // SkillRanger�� Ȱ��ȭ�� ���¿��� ��Ŭ�� ���� �� = ��ų ���
            {
                SkillRange.gameObject.SetActive(false);
                SkillPoints.SP_OnOff(i, false);
                isSkilling = false;
            }

            yield return null;
        }
    }

    public void ChangeMP()
    {

    }

    IEnumerator SkillCool()
    {
        yield return null;
    }
    #endregion

    public void OnSkillEffect()
    {
        GameObject obj = Instantiate(SkillEffct, transform.root) as GameObject;
        obj.transform.position = EffectPos;
    }
}