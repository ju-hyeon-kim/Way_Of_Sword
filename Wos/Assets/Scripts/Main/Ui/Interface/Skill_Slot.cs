using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Slot : MonoBehaviour
{
    public Skill_Data nowSkill;

    public void OnSkillRange(SkillRange skillrange, SkillPoints skillpoints, int key)
    {
        if(transform.childCount > 0) // 자식으로 스킬이 있으면 실행
        {
            nowSkill = transform.GetChild(0).GetComponent<Skill_2D>().myData;

            skillrange.RangeSetting(nowSkill.Range);
            skillpoints.PointSetting(nowSkill.SkillPoint, key);
        }
    }

    public void CreateEffect(int i, Vector3 pos, EffectBin bin)
    {
        if(bin.UsedEffects[i].Name == nowSkill.Name)  // 쓰레기 통에 동일한 이름의 쓰레기가 있을 경우
        {
            bin.UsedEffects[i].transform.position = pos;
            bin.UsedEffects[i].gameObject.SetActive(true);
            bin.UsedEffects[i].GetComponent<ParticleSystem>().Play();
        }
        else // 없을 경우
        {
            Destroy(bin.UsedEffects[i].gameObject);

            GameObject obj = Instantiate(nowSkill.Effect, bin.transform) as GameObject;
            obj.transform.position = pos;

            bin.UsedEffects[i] = obj.GetComponent<Skill_Effect>();
        }
    }
}
