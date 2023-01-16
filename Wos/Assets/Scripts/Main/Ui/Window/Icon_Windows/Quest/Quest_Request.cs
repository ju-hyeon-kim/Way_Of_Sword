using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_Request : MonoBehaviour
{
    public TMP_Text Q_Name;
    public TMP_Text Q_Explanation;
    public GameObject[] Q_Reword;
    public Manager_Quest Manager_Quest;

    Quest_Data myQD;

    public void Accept_Button() // 수락 버튼
    {
        Manager_Quest.Change_NowQuest();
        gameObject.SetActive(false);
    }

    public void Recept_Button() // 거절 버튼
    {
        gameObject.SetActive(false);
    }

    public void Input_Quest_Data(Quest_Data QD) // 퀘스트 데이터 입력
    {
        myQD = QD;

        Q_Name.text = myQD.Name;
        Q_Explanation.text = myQD.Explanation;

        // 퀘스트 데이터의 보상을 보상슬롯에 전달
        for (int i = 0; i < myQD.Reward.Count; i++)
        {
            Instantiate(myQD.Reward[i], Q_Reword[i].transform.GetChild(0));
        }
        // 보상의 갯수에 맞게 보여지는 보상 슬롯의 갯수도 달라짐
        for (int i = myQD.Reward.Count; i < Q_Reword.Length; i++)
        {
            Q_Reword[i].SetActive(false);
        }
    }
}
