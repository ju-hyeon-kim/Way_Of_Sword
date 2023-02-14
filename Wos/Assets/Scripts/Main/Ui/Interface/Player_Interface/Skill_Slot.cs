using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Slot : MonoBehaviour
{
    public SkillData_Window SkillData_Window;
    public Skill_2D nowSkill;
    public Player_Stat P_Stat;


    public void OnSkillRange(SkillRange skillrange, SkillPoints skillpoints, int key)
    {
        if(transform.childCount > 0) // �ڽ����� ��ų�� ������ ����
        {
            skillrange.RangeSetting(nowSkill.myData.Dist);
            skillpoints.PointSetting(nowSkill.myData.SkillPoint, key);
        }
    }

    public void OnSkillEffect(int i, Vector3 pos, EffectBin bin)
    {
        if(bin.UsedEffects[i].Name == nowSkill.myData.Name)  // ������ �뿡 ������ �̸��� �����Ⱑ ���� ���
        {
            bin.UsedEffects[i].transform.position = pos;
            bin.UsedEffects[i].gameObject.SetActive(true);
            bin.UsedEffects[i].GetComponent<ParticleSystem>().Play();
        }
        else // ���� ���
        {
            Destroy(bin.UsedEffects[i].gameObject);

            GameObject obj = Instantiate(nowSkill.myData.Effect, bin.transform) as GameObject;
            obj.transform.position = pos;

            bin.UsedEffects[i] = obj.GetComponent<Skill_Effect>();
        }
        bin.UsedEffects[i].Hit_Skill(Get_SkillAp() + P_Stat.TotalAp_Attack);
    }

    public void OnSkillCool()
    {
        nowSkill.OnCoolTime();
    }

    public bool Get_isCoolTime()
    {
        return nowSkill.Get_isCoolTime();
    }

    public float Get_SkillAp()
    {
        return nowSkill.myData.Ap;
    }
}
