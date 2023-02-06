using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageZone : MonoBehaviour
{

    public Transform[] myPoints;
    public GameObject DamageText;

    GameObject TextObj;

    public void OnDamage(float dmg)
    {
        Battle_Window BW = Dont_Destroy_Data.Inst.Battle_Window;

        //������ ��ȿ� �����Ⱑ ���ٸ� ����
        if(BW.RecycleBin_Dmg.childCount == 0)
        {
            TextObj = Instantiate(DamageText, BW.transform) as GameObject;
        }
        else  //�����Ⱑ �ִٸ� ��Ȱ��
        {
            TextObj = BW.RecycleBin_Dmg.GetChild(0).gameObject;
            TextObj.transform.SetParent(BW.transform);
        }

        int rnd = Random.Range(0, myPoints.Length-1);
        TextObj.GetComponent<DamageText>().myDamageZone = myPoints[rnd];
        TextObj.GetComponent<DamageText>().ShowDamage(dmg);
    }
}
