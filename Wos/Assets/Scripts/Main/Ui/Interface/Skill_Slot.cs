using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Slot : MonoBehaviour
{
    public void OnSkill(SkillRange skillrange, SkillPoints skillpoints, int num)
    {
        if(transform.childCount > 0) // �ڽ����� ��ų�� ������ ����
        {
            Skill_Data mySkill = transform.GetChild(0).GetComponent<Skill_2D>().myData;

            skillrange.RangeSetting(mySkill.Range);
            skillpoints.PointSetting(mySkill.SkillPoint, num);
        }
    }
}
