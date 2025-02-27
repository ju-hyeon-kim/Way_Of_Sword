using UnityEngine;

public class DamageText_Zone : MonoBehaviour
{
    public Transform[] myPoints;
    public GameObject DamageText;

    GameObject TextObj;

    public void OnDamage(float dmg, bool isPlayer, Battle_Window BW)
    {
        //쓰레기 통안에 쓰레기가 없다면 생성
        if (BW.RecycleBin_Dmg.childCount == 0)
        {
            TextObj = Instantiate(DamageText, BW.transform) as GameObject;
        }
        else  //쓰레기가 있다면 재활용
        {
            TextObj = BW.RecycleBin_Dmg.GetChild(0).gameObject;
            TextObj.transform.SetParent(BW.transform);
        }

        int rnd = Random.Range(0, myPoints.Length - 1);
        TextObj.GetComponent<DamageText>().myDamageZone = myPoints[rnd];
        TextObj.GetComponent<DamageText>().ShowDamage(dmg, isPlayer);
    }
}
