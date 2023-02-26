using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTornado_Range : BossSkill_Range
{
    public override void HitTarget()
    {
        StartCoroutine(TimeChecking());
        GetComponent<Collider>().enabled = true;
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

        GetComponent<Collider>().enabled = false;
        myBoss.SkillEnd(SkillNum);
    }
}
