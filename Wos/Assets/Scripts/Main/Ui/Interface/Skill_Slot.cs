using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Slot : MonoBehaviour
{
    public void OnSkill(SkillRange skillrange, SkillPoints skillpoints, int num)
    {
        if(transform.childCount > 0) // 자식으로 스킬이 있으면 실행
        {
            Skill_Data mySkill = transform.GetChild(0).GetComponent<Skill_2D>().myData;

            skillrange.RangeSetting(mySkill.Range);
            skillpoints.PointSetting(mySkill.SkillPoint, num);
        }
    }
}
