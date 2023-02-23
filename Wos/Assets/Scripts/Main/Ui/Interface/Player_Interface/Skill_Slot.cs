using UnityEngine;

public class Skill_Slot : MonoBehaviour
{
    public SkillData_Window SkillData_Window;
    public Player_Stat P_Stat;
    public bool isEmpty = true;

    Skill_2D nowSkill;

    public void Save_nowSkill()
    {
        nowSkill = transform.GetChild(0).GetComponent<Skill_2D>();
    }

    public void OnSkillRange(SkillRange skillrange, SkillPoints skillpoints, int key)
    {
        if (transform.childCount > 0) // �ڽ����� ��ų�� ������ ����
        {
            skillrange.RangeSetting(nowSkill.myData.Dist);
            skillpoints.PointSetting(nowSkill.myData.SkillPoint, key);
        }
    }

    public void OnSkillEffect(int i, Vector3 pos, EffectBin bin)
    {
        if (bin.UsedEffects[i].Name == nowSkill.myData.Name)  // ������ �뿡 ������ �̸��� �����Ⱑ ���� ���
        {
            if (nowSkill.myData.SkillPoint.GetComponent<SkillPoint>().skilltype == SKILLTYPE.RANGE)
            {
                bin.UsedEffects[i].transform.position = pos;
            }
            else
            {
                bin.UsedEffects[i].transform.position = Dont_Destroy_Data.Inst.Player.transform.position + new Vector3(0, 1, 0);
                pos.y = bin.UsedEffects[i].transform.position.y;
                bin.UsedEffects[i].transform.LookAt(pos);
            }

            bin.UsedEffects[i].gameObject.SetActive(true);
            bin.UsedEffects[i].GetComponent<ParticleSystem>().Play();
        }
        else // ���� ���
        {
            Destroy(bin.UsedEffects[i].gameObject);

            GameObject obj = Instantiate(nowSkill.myData.Effect, bin.transform) as GameObject;
            bin.UsedEffects[i] = obj.GetComponent<Skill_Effect>();

            if (nowSkill.myData.SkillPoint.GetComponent<SkillPoint>().skilltype == SKILLTYPE.RANGE)
            {
                bin.UsedEffects[i].transform.position = pos;
            }
            else
            {
                bin.UsedEffects[i].transform.position = Dont_Destroy_Data.Inst.Player.transform.position + new Vector3(0, 1, 0);
                pos.y = bin.UsedEffects[i].transform.position.y;
                bin.UsedEffects[i].transform.LookAt(pos);
            }
        }


        if (nowSkill.myData.SkillPoint.GetComponent<SkillPoint>().skilltype == SKILLTYPE.RANGE)
        {
            bin.UsedEffects[i].Hit_RangeSkill(Get_SkillAp() + P_Stat.TotalAp_Attack);
        }
        else
        {
            bin.UsedEffects[i].Hit_VectorSkill(Get_SkillAp() + P_Stat.TotalAp_Attack, pos);
        }
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

    public float Get_SkillMp()
    {
        return nowSkill.myData.Mp;
    }

    public void isNone_Skill()
    {
        Destroy(nowSkill.gameObject);
        nowSkill = null;
        isEmpty = true;
    }
}
