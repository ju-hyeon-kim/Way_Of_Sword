using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Proceeding_Quest : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Explanation;
    public TMP_Text Progress;
    public GameObject[] Reward_Slots;
    public GameObject[] isQuesting_Obj;
    public Quest_SubWindow Quest_SubWindow;
    public Quest_List Quest_List;

    Quest_Data NowQD;

    public void Update_ProceedingQuest(Quest_Data QD,  bool b)
    {
        NowQD = QD;

        if (b) // 현재 진행중이 퀘스트가 있을 경우
        {
            isQuesting_Obj[0].SetActive(false);
            isQuesting_Obj[1].SetActive(true);

            Name.text = NowQD.Name;
            Explanation.text = NowQD.Explanation;
            // 퀘스트 데이터의 보상을 보상슬롯에 전달
            for (int i = 0; i < NowQD.Reward.Count; i++)
            {
                Instantiate(NowQD.Reward[i], Reward_Slots[i].transform.GetChild(0));
            }
            // 보상의 갯수에 맞게 보여지는 보상 슬롯의 갯수도 달라짐
            for (int i = NowQD.Reward.Count; i < Reward_Slots.Length; i++)
            {
                Reward_Slots[i].SetActive(false);
            }
        }
        else // 현재 진행중이 퀘스트가 없을 경우
        {
            isQuesting_Obj[0].SetActive(true);
            isQuesting_Obj[1].SetActive(false);
        }
    }

    public void Quest_Complete()
    {
        Update_ProceedingQuest(NowQD, false);
        Quest_List.Quest_Complete();
    }
}
