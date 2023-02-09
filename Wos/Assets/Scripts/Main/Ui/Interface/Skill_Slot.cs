using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Slot : MonoBehaviour
{
    public Skill_Data nowSkill;

    public void OnSkillRange(SkillRange skillrange, SkillPoints skillpoints, int key)
    {
        if(transform.childCount > 0) // �ڽ����� ��ų�� ������ ����
        {
            nowSkill = transform.GetChild(0).GetComponent<Skill_2D>().myData;

            skillrange.RangeSetting(nowSkill.Range);
            skillpoints.PointSetting(nowSkill.SkillPoint, key);
        }
    }

    public void OnSkill(Vector3 pos)
    {
        GameObject obj = Instantiate(nowSkill.Effect, transform.root) as GameObject;
        obj.transform.position = pos;
    }
}
