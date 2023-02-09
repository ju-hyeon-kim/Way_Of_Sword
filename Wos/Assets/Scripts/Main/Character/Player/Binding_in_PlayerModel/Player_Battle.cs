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
            //몬스터를 클릭할 경우 -> 몬스터에게 이동 후 콤보어택
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster") && !myAnim.GetBool("isAttacking"))
            {
                myEnemy = hit.collider.gameObject;
                if(!SkillRange.gameObject.activeSelf) // Skill Range가 켜져있을 경우 기본 공격 불가
                {
                    base.MoveToPos(hit.point, () => GetComponent<Animator>().SetTrigger("ComboAttack"));
                }
            }
            //Npc를 클릭할 경우 -> Npc에게 이동
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
        if (myAnim.GetBool("isIdle")) // 공격중에는 Damage 애니 작동불가, 단, 체력은 깎임
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
        //SkillRange, SkillPoint data 가져오기
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
                //히트 포지션에 따라 스킬포인트의 포지션을 업데이트
                SkillPoints.PosUpdating(i, hit.point);

                if(Input.GetMouseButtonDown(0)) // 좌클릭 = 스킬발동
                {
                    //생성할 이펙트와 이펙트의 생성위치 설정
                    SkillEffct = Skill_Set.Slots[i].nowSkill.Effect;
                    EffectPos = hit.point;

                    //SkillRange, SkillPoint unActive
                    SkillRange.gameObject.SetActive(false);
                    SkillPoints.SP_OnOff(i, false);

                    //끝나면 스킬 발동
                    isJustMove = false;
                    Vector3 vec = hit.point - transform.position;
                    AttackRange = vec.magnitude;
                    base.MoveToPos(hit.point, () => GetComponent<Animator>().SetTrigger("Qskill"));
                }
            }
            else // SkillRange의 범위를 벗어 났을 때
            {
                SkillPoints.SP_OnOff(i, false);
            }

            if (Input.GetMouseButtonDown(1)) // SkillRanger가 활성화된 상태에서 우클릭 했을 때 = 스킬 취소
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