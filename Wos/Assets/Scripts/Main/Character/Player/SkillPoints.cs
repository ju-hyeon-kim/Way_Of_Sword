using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoints : MonoBehaviour
{
    public GameObject[] myPoints = new GameObject[4];

    public void PointSetting(SkillPoint skillpoint, int num)
    {
        bool isNonePoint = !myPoints[num].TryGetComponent<SkillPoint>(out SkillPoint component);

        if(isNonePoint)
        {
            GameObject obj = Instantiate(skillpoint.gameObject, transform) as GameObject;
            myPoints[num] = obj;
        }
        else
        {
            bool isNewPoint = myPoints[num].GetComponent<SkillPoint>().Name != skillpoint.Name;
            if (isNewPoint)
            {
                GameObject obj = Instantiate(skillpoint.gameObject, transform) as GameObject;
                myPoints[num] = obj;
            }
        }
    }

    public void OnSkill(int i)
    {
        myPoints[i].SetActive(true);
    }
}
