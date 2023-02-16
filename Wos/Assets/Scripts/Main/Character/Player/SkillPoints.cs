using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;



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

    public void SP_OnOff(int i, bool b, Vector3 pos = default) //마우스의 위치에 따라
    {
        if(b != myPoints[i].activeSelf)
        {
            myPoints[i].SetActive(b);
        }

        if(b == true)
        {
            if(myPoints[i].GetComponent<SkillPoint>().skilltype == SKILLTYPE.RANGE) // 범위형 타입 => 포인트의 위치 조정
            {
                pos += new Vector3(0, 0.01f, 0); // 높이 조정
                myPoints[i].transform.position = pos;
            }
            else //방향형 타입 => 회전값 조정
            {

                myPoints[i].transform.position = Dont_Destroy_Data.Inst.Player.position + new Vector3(0, 0.01f, 0);
                myPoints[i].transform.LookAt(pos);
            }
        }
    }
}
