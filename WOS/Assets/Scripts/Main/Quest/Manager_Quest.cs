using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Quest : MonoBehaviour
{
    public Proceeding_Quest Proceeding_Quest;
    public Quest_List Quest_List;
    public Quest_Data NowQuest;

    private void Awake()
    {
        DontDestroyOnLoad(this); // 씬전환 시 파괴되지 않음
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
}
