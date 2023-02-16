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

    public void SP_OnOff(int i, bool b, Vector3 pos = default) //���콺�� ��ġ�� ����
    {
        if(b != myPoints[i].activeSelf)
        {
            myPoints[i].SetActive(b);
        }

        if(b == true)
        {
            if(myPoints[i].GetComponent<SkillPoint>().skilltype == SKILLTYPE.RANGE) // ������ Ÿ�� => ����Ʈ�� ��ġ ����
            {
                pos += new Vector3(0, 0.01f, 0); // ���� ����
                myPoints[i].transform.position = pos;
            }
            else //������ Ÿ�� => ȸ���� ����
            {

                myPoints[i].transform.position = Dont_Destroy_Data.Inst.Player.position + new Vector3(0, 0.01f, 0);
                myPoints[i].transform.LookAt(pos);
            }
        }
    }
}
