using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Effect : MonoBehaviour
{
    public string Name;

    public void Hit_RangeSkill(float SkillAp)
    {
        {
            Collider[] list = Physics.OverlapSphere(transform.position, 0.7f, LayerMask.NameToLayer("Monset"));

            foreach (Collider col in list)
            {
                col.GetComponent<Monster_Movement>()?.OnDamage(SkillAp);
            }
        }
    }

    public virtual void Hit_VectorSkill(float SkillAp, Vector3 pos) { } //HitCollider 이동시키기
}
