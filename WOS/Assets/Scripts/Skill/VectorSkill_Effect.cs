using System.Collections;
using UnityEngine;

public class VectorSkill_Effect : Skill_Effect
{
    public HitCollider_SkillEffect Hit_Collider;

    public override void Hit_VectorSkill(float SkillAp, Vector3 pos) //HitCollider 이동시키기
    {
        Hit_Collider.Damage = SkillAp;
        StartCoroutine(Moving_HitCollider(pos));
    }

    IEnumerator Moving_HitCollider(Vector3 pos)
    {
        pos.y = transform.position.y;
        Vector3 dir = pos - transform.position;
        dir.Normalize();
        float dist = 8.0f;
        float speed = 7.5f;

        while (dist > 0)
        {
            float delta = speed * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            Hit_Collider.transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        yield return new WaitForSeconds(1.0f);
        Hit_Collider.transform.localPosition = Vector3.zero;
    }
}
