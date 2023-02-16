using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider_SkillEffect : MonoBehaviour
{
    public float Damage = 0;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Monster_Movement>()?.OnDamage(Damage);
    }
}
