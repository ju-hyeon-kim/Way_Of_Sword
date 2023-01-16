using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Quest : MonoBehaviour
{
    public Proceeding_Quest Proceeding_Quest;
    public Quest_SubWindow Quest_SubWindow;
    public Quest_List Quest_List;

    public Quest_Data[] Quest_Prefabs;
    Quest_Data NowQuest;


    private void Start()
    {
        Instantiate(Quest_Prefabs[0], transform);
        NowQuest = transform.GetChild(0).GetComponent<Quest_Data>();

        //Quest_SubWindow와 연동
        Conect_SubWindow(true);

        //'Proceeding_Quest'와 연동
        Conect_Proceeding_Quest();

        //Quest List의 Po_Qeusts[0] 활성화
        Conect_Qeust_List(0);

        //퀘스팅 실행
        OnStart_Questing();
    }

    public void OnStart_Questing()
    {
        GetComponentInChildren<Quest_Data>().Start_Questing();
    }

    public void Conect_Proceeding_Quest()
    {
        //퀘스트의 정보를 진행중 퀘스트 윈도우에 전달
        NowQuest = transform.GetChild(0).GetComponent<Quest_Data>();
        Proceeding_Quest.Update_ProceedingQuest(NowQuest, true);
    }

    public void Conect_Qeust_List(int num)
    {
        QL_Quest QLQ = Quest_List.QL_Quests[num];
        QLQ.Q_Name.text = NowQuest.Name;
        QLQ.Q_Name.fontSize = 20f;
        QLQ.State.SetActive(true);

        for (int i = 0; i < Quest_List.QL_Quests[num].Q_Reword.Length; i++)
        {
            if(i < NowQuest.Reward.Count)
            {
                Instantiate(NowQuest.Reward[i], QLQ.Q_Reword[i].transform.GetChild(0));
                QLQ.Q_Reword[i].transform.GetChild(1).gameObject.SetActive(false); // hidden_text
            }
            else
            {
                QLQ.Q_Reword[i].SetActive(false);
            }
        }
    }

    public void Conect_SubWindow(bool isQuesting)
    {
        Quest_SubWindow.Update_Window(NowQuest, true, isQuesting); // 트루를 나중에 바꿔줌
    }
}
