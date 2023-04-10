using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBolt_Range : BossSkill_Range
{
    public override void HitTarget()
    {
        StartCoroutine(TimeChecking());
        StartCoroutine(coDamage_OverTime());
    }

    IEnumerator coDamage_OverTime() // Áö¼Óµô
    {
        while (SkillDuration > 0)
        {
            GetComponent<Collider>().enabled = true;
            yield return new WaitForSeconds(1.0f);
            GetComponent<Collider>().enabled = false;
            yield return null;
        }
    }

    IEnumerator TimeChecking()
    {
        float saveDtration = SkillDuration;
        while (SkillDuration > 0)
        {
            SkillDuration -= Time.deltaTime;
            yield return null;
        }
        SkillDuration = saveDtration;
        myBoss.SkillEnd(SkillNum);
    }
}
