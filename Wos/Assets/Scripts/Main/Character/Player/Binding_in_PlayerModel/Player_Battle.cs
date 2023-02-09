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
            //몬스터를 클릭할 경우 -> 몬스터에게 이동 후 콤보어택
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster") && !myAnim.GetBool("isAttacking"))
            {
                myTarget = hit.collider.transform;
                if(Manager_Skill.GetRangeActive()) // Skill Range가 켜져있을 경우 기본 공격 불가
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

            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f,1 << LayerMask.NameToLayer("SkillRange"))) // 마우스 포지션이 SkillRange를 감지했으면
            {
                Manager_Skill.MouseOnSkillRange(i, hit.point);

                if (Input.GetMouseButtonDown(0)) // 좌클릭 = 스킬발동
                {
                    //스킬이펙트 생성위치 설정
                    EffectPos = hit.point;
                    SkillNum = i;

                    //이동중이라면 이동 멈춤
                    GetComponent<Player_Movement>().Stop_Movement();

                    //끝나면 스킬 발동
                    base.MoveToPos(hit.point, null, false, true); // 회전만 적용
                    myAnim.SetTrigger("Qskill");

                    StopSkilling(i);
                }
            }
            else // SkillRange의 범위를 벗어 났을 때
            {
                Manager_Skill.UnActive_Point(i);
            }

            if (Input.GetMouseButtonDown(1)) // SkillRanger가 활성화된 상태에서 우클릭 했을 때 = 스킬 취소
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