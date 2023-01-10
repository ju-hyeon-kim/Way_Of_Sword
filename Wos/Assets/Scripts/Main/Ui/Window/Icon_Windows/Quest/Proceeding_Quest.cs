using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Proceeding_Quest : MonoBehaviour
{
    public Quest_Data Quest_Data;
    public TMP_Text Quest_Name;
    public TMP_Text Quest_Explanation;
    public TMP_Text Quest_Progress;
    public GameObject[] Reward_Slots;

    public Quest_SubWindow Quest_SubWindow;

    private void Awake()
    {
        Quest_Name.text = Quest_Data.Name;
        Quest_Explanation.text = Quest_Data.Explanation;

        // 퀘스트 데이터의 보상을 보상슬롯에 전달
        for (int i = 0; i < Quest_Data.Reward.Count; i++)
        {
            Reward_Slots[i].transform.GetChild(i).GetComponent<Image>().sprite = Quest_Data.Reward[i].Image;
        }
        // 보상의 갯수에 맞게 보여지는 보상 슬롯의 갯수도 달라짐
        for (int i = Quest_Data.Reward.Count; i < Reward_Slots.Length; i++)
        {
            Reward_Slots[i].SetActive(false);
        }
        // 서브 윈도우와 연결
        Conect_SubWindow();
    }

    void Conect_SubWindow()
    {
        Quest_SubWindow.Name.text = Quest_Data.Name;
        Quest_SubWindow.Explanation.text = Quest_Data.Explanation;
        Quest_SubWindow.Progress.text = Quest_Progress.text;
    }
}
