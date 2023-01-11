using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Quest : MonoBehaviour // 진행중 퀘스트 윈도우, 서브 윈도우 제어
{
    public Quest_Data[] QuestList; // 퀘스트들
    public Proceeding_Quest Proceeding_Quest;
    public Quest_SubWindow Quest_SubWindow;


    private void Awake()
    {
        DontDestroyOnLoad(this); // 씬전환 시 파괴되지 않음
    }

    private void Start()
    {
        //0번째 퀘스트 생성
        Instantiate(QuestList[0],transform);
        Quest_Data QD = transform.GetChild(0).GetComponent<Quest_Data>();

        //퀘스트의 정보를 진행중 퀘스트 윈도우에 전달
        Update_ProceedingQuest(QD);

        //퀘스트의 정보를 서브 윈도우에 전달
        Update_SubWindow(QD);

        //퀘스팅 코루틴 실행 ( 진행중/완료 여부를 감지 )
        QD.Start_Questing();
    }

    public void Update_ProceedingQuest(Quest_Data QD) 
    {
        Proceeding_Quest.Name.text = QD.Name;
        Proceeding_Quest.Explanation.text = QD.Explanation;
        // 퀘스트 데이터의 보상을 보상슬롯에 전달
        for (int i = 0; i < QD.Reward.Count; i++)
        {
            Proceeding_Quest.Reward_Slots[i].transform.GetChild(i).GetComponent<Image>().sprite = QD.Reward[i].Image;
        }
        // 보상의 갯수에 맞게 보여지는 보상 슬롯의 갯수도 달라짐
        for (int i = QD.Reward.Count; i < Proceeding_Quest.Reward_Slots.Length; i++)
        {
            Proceeding_Quest.Reward_Slots[i].SetActive(false);
        }
    }

    public void Update_SubWindow(Quest_Data QD)
    {
        Quest_SubWindow.Name.text = QD.Name;
        Quest_SubWindow.Explanation.text = QD.Explanation;
        Quest_SubWindow.Progress.text =  Proceeding_Quest.Progress.text;
        Quest_SubWindow.Progress.color = Proceeding_Quest.Progress.color;
    }
}
