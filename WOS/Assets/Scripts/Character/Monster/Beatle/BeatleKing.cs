using System.Collections;
using UnityEngine;

public class BeatleKing : BossMonster
{
    [Header("-----BeatleKing-----")]
    GameObject EffectObj;
    Coroutine SoundCoroutine = null;

    public override void SkillReady(int skillnum)
    {
        myAnim.SetBool("SkillReady", true);
        Skill_Ranges[skillnum].gameObject.SetActive(true);
        //sfx
        if(skillnum == 0)
        {
            SoundPlay(3);
        }
        else if(skillnum == 1)
        {
            SoundPlay(4);
            myAudio.loop = true;
        }
    }
    public override void SkillAction(int skillnum) 
    {
        //sfx
        myAudio.Stop();
        myAudio.loop = false;

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

    public void HowlSound() //animevent
    {
        myAudio.clip = AudioClips[0];
        myAudio.Play();
    }
}
