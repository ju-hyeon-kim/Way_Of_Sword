using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class QL_Quest : MonoBehaviour
{
    public Quest_Data Quest_Data;

    public TMP_Text Q_Name;
    public GameObject[] Q_Reword;
    public GameObject Lock;
    public GameObject State;
    public GameObject Complete;

    public void Complete_Quest()
    {
        State.SetActive(false);
        Complete.SetActive(true);
    }

    public void UnLock_Quest()
    {
        //퀘스트 이름
        Q_Name.text = Quest_Data.Name;
        Q_Name.fontSize = 18f;
        //보상 슬롯
        for(int i = 0; i < 3; i++)
        {
            // 퀘스트의 보상 갯수만큼 보상슬롯 활성화
            if (i >= Quest_Data.Reward.Length)
            {
                Q_Reword[i].SetActive(false);
            }
            else
            {
                Instantiate(Quest_Data.Reward[i], Q_Reword[i].transform.GetChild(1)); // Icon_Area의 자식으로 아이템 오브젝트 생성
            }
        }
        //"진행가능"
        State.SetActive(true);

        //Lock 해제
        Lock.SetActive(false);
    }
}
