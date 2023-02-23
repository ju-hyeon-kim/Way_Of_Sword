using UnityEngine;

public class DamageText_Zone : MonoBehaviour
{
    public Transform[] myPoints;
    public GameObject DamageText;

    GameObject TextObj;

    public void OnDamage(float dmg, bool isPlayer, Battle_Window BW)
    {
        //������ ��ȿ� �����Ⱑ ���ٸ� ����
        if (BW.RecycleBin_Dmg.childCount == 0)
        {
            TextObj = Instantiate(DamageText, BW.transform) as GameObject;
        }
        else  //�����Ⱑ �ִٸ� ��Ȱ��
        {
            TextObj = BW.RecycleBin_Dmg.GetChild(0).gameObject;
            TextObj.transform.SetParent(BW.transform);
        }

        int rnd = Random.Range(0, myPoints.Length - 1);
        TextObj.GetComponent<DamageText>().myDamageZone = myPoints[rnd];
        TextObj.GetComponent<DamageText>().ShowDamage(dmg, isPlayer);
    }
}
