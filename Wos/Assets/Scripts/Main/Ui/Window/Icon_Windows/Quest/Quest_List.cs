using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_List : MonoBehaviour
{
    public QL_Quest[] QL_Quests;
    public Manager_Quest Manager_Quest;

    public void Update_Data()
    {

    }

    public void Quest_Complete(Quest_Data nextQD)
    {
        // 완료된 퀘스트 -> 완료 도장 찍기
        QL_Quests[nextQD.Quest_Number - 1].Complete_Quest();

        // 다음 퀘스트에 퀘스트 적용
        QL_Quests[nextQD.Quest_Number].UnLock_Quest();
    }
}
