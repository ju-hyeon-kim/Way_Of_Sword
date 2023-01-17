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
    public TMP_Text Countig_Text;
    public GameObject[] Reward_Slots;
    public GameObject[] Q_Exist_Settings; // 현재 퀘스트가 존재하는지 안하는지에 따라 달라지는 세팅값

    public void Change_Quest(Quest_Data QD)
    {
        Q_Exist_Settings[0].SetActive(false);
        Q_Exist_Settings[1].SetActive(true);

        Name.text = QD.Name;
        Explanation.text = QD.Explanation;
        // 퀘스트 데이터의 보상을 보상슬롯에 전달
        for (int i = 0; i < QD.Reward.Count; i++)
        {
            Instantiate(QD.Reward[i], Reward_Slots[i].transform.GetChild(0));
        }
        // 보상의 갯수에 맞게 보여지는 보상 슬롯의 갯수도 달라짐
        for (int i = QD.Reward.Count; i < Reward_Slots.Length; i++)
        {
            Reward_Slots[i].SetActive(false);
        }
        Progress.text = "진행중";
        Progress.color = Color.white;
        //카운트를 세는 퀘스트인지 검사
        if(QD.isCounting())
        {
            Countig_Text.text = $"({QD.Now_Count()}/{QD.Max_Count()})";
            Countig_Text.gameObject.SetActive(true);
        }
        else
        {
            Countig_Text.gameObject.SetActive(false);
        }
    }

    public void Complete_Quest()
    {
        Progress.text = "완료";
        Progress.color = Color.green;
    }

    public void None_Quest()
    {
        Q_Exist_Settings[0].SetActive(true);
        Q_Exist_Settings[1].SetActive(false);
    }
}
