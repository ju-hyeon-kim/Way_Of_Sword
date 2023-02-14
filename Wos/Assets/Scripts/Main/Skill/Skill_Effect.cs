using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Effect : MonoBehaviour
{
    public string Name;

    public void Hit_Skill(float SkillAp)
    {
        Collider[] list = Physics.OverlapSphere(transform.position, 0.7f, LayerMask.NameToLayer("Monset"));

        foreach (Collider col in list)
        {
            col.GetComponent<Monster_Movement>()?.OnDamage(SkillAp);
        }
    }
}
