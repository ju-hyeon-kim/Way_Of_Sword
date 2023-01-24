using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_List : MonoBehaviour
{
    public QL_Quest[] QL_Quests;
    public Manager_Quest Manager_Quest;

    public void Change_Quest(Quest_Data QD)
    {
        QL_Quest QLQ = QL_Quests[QD.Quest_Number];
        QLQ.Q_Name.text = QD.Name;
        QLQ.Q_Name.fontSize = 20f;
        QLQ.State.SetActive(true);
        QLQ.State.transform.GetChild(0).GetComponent<TMP_Text>().text = "진행중";

        for (int i = 0; i < QLQ.Q_Reword.Length; i++)
        {
            if (i < QD.Reward.Count)
            {
                Instantiate(QD.Reward[i], QLQ.Q_Reword[i].transform.GetChild(0));
                QLQ.Q_Reword[i].transform.GetChild(1).gameObject.SetActive(false); // hidden_text
            }
            else
            {
                QLQ.Q_Reword[i].SetActive(false);
            }
        }
    }

    public void None_Quest(int next_Qnum)
    {
        // 완료된 퀘스트 -> 완료 도장 찍기
        QL_Quests[next_Qnum - 1].Complete_Quest();

        // 다음 퀘스트에 퀘스트 적용
        QL_Quests[next_Qnum].UnLock_Quest();
    }
}
