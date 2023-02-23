using UnityEngine;

public class Skill_Interface : Hp_Interface
{
    [Header("-----Skill_Interface_____")]
    public SkillRange SkillRange;
    public SkillPoints SkillPoints;
    public Skill_Set Skill_Set;
    public EffectBin EffectBin;

    public bool isEmpyhSlot(int i)
    {
        return Skill_Set.Slots[i].isEmpty;
    }

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
        //��Ʈ �����ǿ� ���� ��ų����Ʈ�� �������� ������Ʈ
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
        Skill_Set.Slots[i].OnSkillEffect(i, pos, EffectBin);
        OnSkillCool(i);

        float SkillMp = Skill_Set.Slots[i].Get_SkillMp();
        UseMp(SkillMp);
    }

    void OnSkillCool(int i)
    {
        Skill_Set.Slots[i].OnSkillCool();
    }

    public bool isPossibeSkill(int i, float CurMp)
    {
        bool isCoolTime = Skill_Set.Slots[i].Get_isCoolTime();
        bool MpisSuffice = CurMp >= Skill_Set.Slots[i].Get_SkillMp();
        return !isCoolTime && MpisSuffice; // ������ ��� �ϰų� ��Ÿ���� �ƴϾ�� true�� ��ȯ�� 
    }
}
