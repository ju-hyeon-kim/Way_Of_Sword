using UnityEngine;

public class BeatleKing : BossMonster
{
    [Header("-----BeatleKing-----")]
    GameObject EffectObj;

    public override void SkillReady(int skillnum)
    {
        myAnim.SetBool("SkillReady", true);
        Skill_Ranges[skillnum].gameObject.SetActive(true);
    }

    public override void SkillAction(int skillnum) 
    {
        myAnim.SetBool("SkillReady", false);
        EffectObj = Instantiate(Skill_Effects[skillnum], SkillEffect_Pos[skillnum]) as GameObject;
        if (skillnum == 0) // ThunderBolt -> 쏘는 방향 설정
        {
            EffectObj.transform.rotation = SkillEffect_Pos[skillnum].rotation;
        }
        Skill_Ranges[skillnum].HitTarget();
    }

    public override void SkillEnd(int skillnum)
    {
        EffectObj.SetActive(false);
        Skill_Ranges[skillnum].gameObject.SetActive(false);
        AttackTarget(myTarget, myStat.arange(), myStat.aspeed());
    }
}
