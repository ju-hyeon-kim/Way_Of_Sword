using UnityEngine;

public class BeatleKing : BossMonster
{
    //[Header("-----BeatleKing-----")]


    public override void Skill1()
    {
        myAnim.SetBool("SkillReady", true);
    }

    public override void Skill2()
    {
        base.Skill2();
    }
}
