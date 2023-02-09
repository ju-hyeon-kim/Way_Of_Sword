using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager_Skill : MonoBehaviour
{
    public SkillRange SkillRange;
    public SkillPoints SkillPoints;
    public Skill_Set Skill_Set;
    public EffectBin EffectBin;
    
    public bool GetRangeActive()
    {
        bool b = SkillRange.gameObject.activeSelf;
        return b;
    }

    public void OnSkillRange(int i)
    {
        Skill_Set.Slots[i].OnSkillRange(SkillRange, SkillPoints, i);
        SkillRange.gameObject.SetActive(true);
    }

    public void MouseOnSkillRange(int i, Vector3 pos)
    {
        //히트 포지션에 따라 스킬포인트의 포지션을 업데이트
        SkillPoints.SP_OnOff(i, true, pos);
    }

    public void UnActive_RangeAndPoint(int i)
    {
        SkillRange.gameObject.SetActive(false);
        UnActive_Point(i);
    }

    public void UnActive_Point(int i)
    {
        SkillPoints.SP_OnOff(i, false);
    }

    public void OnSkillEffect(int i, Vector3 pos)
    {
        Skill_Set.Slots[i].CreateEffect(i, pos, EffectBin);
    }
}
