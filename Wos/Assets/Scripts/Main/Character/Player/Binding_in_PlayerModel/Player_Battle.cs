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
            //몬스터를 클릭할 경우 -> 몬스터에게 이동 후 콤보어택
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster") && !myAnim.GetBool("isAttacking"))
            {
                myTarget = hit.collider.transform;
                if(!myInterface.GetRangeActive()) // Skill Range가 꺼져있을 경우만 기본 공격 가능
                {

                    base.MoveToPos(hit.point, () => GetComponent<Animator>().SetTrigger("ComboAttack"));
                }
            }
            //Npc를 클릭할 경우 -> Npc에게 이동 후 말걸기
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

        if (myAnim.GetBool("isIdle")) // 공격중에는 Damage 애니 작동불가, 단, 체력은 깎임
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
        if(GetComponent<Player>().nowMode == Mode.BATTLE) // 배틀모드라면
        {
            if (myInterface.isPossibeSkill(i, myStat.curmp())) // 쿨타임이 아니고 사용 가능한 마나가 있을 경우
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

            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f,1 << LayerMask.NameToLayer("SkillRange"))) // 마우스 포지션이 SkillRange를 감지했으면
            {
                myInterface.MouseOnSkillRange(i, hit.point);

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
                myInterface.UnActive_Point(i);
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
        myInterface.UnActive_RangeAndPoint(i);
        isSkilling = false;
    }

    public void OnSkillEffct()
    {
        myInterface.OnSkillEffect(SkillNum, EffectPos); // 스킬의 공격력을 어떻게 가져올까
    }
    #endregion

    #region for ItmeDrop
    public override void Pickup_Item()
    {
        DropRange.Pickup_Item();
    }
    #endregion
}