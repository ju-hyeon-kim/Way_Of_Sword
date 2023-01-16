using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_List : MonoBehaviour
{
    public Quest_Data[] Quest_Datas; // 퀘스트들
    public QL_Quest[] QL_Quests;
    public Manager_Quest Manager_Quest;

    Quest_Data QD;

    private void Start()
    {
        

        
    }

    //퀘스트 완료-> 현재 퀘스트 컴플리트,다음 퀘스트 잠금 해제
    public void Quest_Complete()
    {
        //int num = Manager_Quest.NowQuest.Quest_Number;

        //완료된 퀘스트 "Complete" 도장찍기
        //QL_Quests[num].Complete_Quest();
        //다음 퀘스트 잠금해제
        //QL_Quests[num + 1].UnLock_Quest();
    }
}
