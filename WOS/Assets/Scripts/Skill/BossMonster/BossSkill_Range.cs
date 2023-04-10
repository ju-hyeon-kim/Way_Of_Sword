using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill_Range : MonoBehaviour
{
    public BossMonster myBoss;

    // 인스펙터에서 설정
    public int SkillNum; 
    public float SkillDuration;
    public float Dmg;

    Transform target = null;
 
    public void CastEnd() // AnimEvent
    {
        myBoss.SkillAction(SkillNum);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            target = other.transform;
            target.GetComponent<Player>().OnDamage(Dmg);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (target != null)
        {
            target = null;
        }
    }

    public virtual void HitTarget() { }
}
