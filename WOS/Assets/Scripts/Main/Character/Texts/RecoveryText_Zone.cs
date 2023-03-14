using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryText_Zone : MonoBehaviour
{
    public GameObject RecoveryText;
    public Hp_Set Hp_Set;
    public Mp_Set Mp_Set;

    GameObject TextObj;
    public void OnRecoveryText(float Ap, bool isHp, Battle_Window BW)
    {
        //쓰레기 통안에 쓰레기가 없다면 생성
        if (BW.RecycleBin_RecoveryText.childCount == 0)
        {
            TextObj = Instantiate(RecoveryText, BW.transform) as GameObject;
        }
        else  //쓰레기가 있다면 재활용
        {
            TextObj = BW.RecycleBin_RecoveryText.GetChild(0).gameObject;
            TextObj.transform.SetParent(BW.transform);
        }

        TextObj.GetComponent<RecoveryText>().myTextZone = this.transform;
        TextObj.GetComponent<RecoveryText>().ShowRecoveryAp(Ap, isHp);

        if(isHp)
        {
            Hp_Set.Update_Ui();
        }
        else
        {
            Mp_Set.Update_Ui();
        }
    }
}
