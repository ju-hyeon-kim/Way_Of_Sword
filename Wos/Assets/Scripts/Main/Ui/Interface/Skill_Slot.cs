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

    public void CreateEffect(int i, Vector3 pos, EffectBin bin)
    {
        if(bin.UsedEffects[i].Name == nowSkill.Name)  // ������ �뿡 ������ �̸��� �����Ⱑ ���� ���
        {
            bin.UsedEffects[i].transform.position = pos;
            bin.UsedEffects[i].gameObject.SetActive(true);
            bin.UsedEffects[i].GetComponent<ParticleSystem>().Play();
        }
        else // ���� ���
        {
            Destroy(bin.UsedEffects[i].gameObject);

            GameObject obj = Instantiate(nowSkill.Effect, bin.transform) as GameObject;
            obj.transform.position = pos;

            bin.UsedEffects[i] = obj.GetComponent<Skill_Effect>();
        }
    }
}
