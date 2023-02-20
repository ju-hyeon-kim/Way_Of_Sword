using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Quest : MonoBehaviour
{
    public Proceeding_Quest Proceeding_Quest;
    public Quest_SubWindow Quest_SubWindow;
    public Quest_List Quest_List;
    public GameObject[] Quest_Prefabs;
    public Quest_Request Quest_Request;
    public int Quest_Num = 0;
    public Quest_Guide Quest_Guide;
    public Transform[] Guide_Tartgets; // Guide_Tartgets[num] = Quest_num의 타겟
    public Quest_Data NowQuest;

    public void Start_Setting(Transform PlaceManager)
    {
        Guide_Tartgets = PlaceManager.GetComponent<Manager_Place>().Guide_Tartgets;
        Change_Quest();
    }

    public void Change_Quest()
    {
        if (transform.childCount > 0) // 매니저에게 자식이 있다면 = 기존의 퀘스트가 생성되어있다면
        {
            Destroy(transform.GetChild(0).gameObject); // 해당 퀘스트 파괴
        }
        GameObject obj = Instantiate(Quest_Prefabs[Quest_Num], transform);
        NowQuest = obj.GetComponent<Quest_Data>();

        Quest_List.Change_Quest(NowQuest);
        Proceeding_Quest.Change_Quest(NowQuest);
        Quest_SubWindow.Change_Quest(NowQuest);

        NowQuest.GetComponent<Quest_Data>().Quest_isStart = true;
        NowQuest.GetComponent<Quest_Data>().Start_Questing();

        Quest_Guide.Change_Quest();
    }

    public void Complete_Quest()
    {
        Proceeding_Quest.Complete_Quest();
        Quest_SubWindow.Complete_Quest();
        Quest_Guide.Complete_Quest();
    }

    public void None_Qeust()
    {
        ++Quest_Num;

        Proceeding_Quest.None_Quest();
        Quest_SubWindow.None_Quest();
        Quest_List.None_Quest(Quest_Num);

        //퀘스트 신청서에 다음 퀘스트 정보 전달
        Quest_Request.Input_QuestData(Quest_Prefabs[Quest_Num].GetComponent<Quest_Data>());
    }

    public void Add_KillCount(int count)
    {
        Proceeding_Quest.Add_KillCount(count);
        Quest_SubWindow.Add_KillCount(count);
    }

    public void SceneChange() //로딩씬으로 넘어갈 때 Missing 오류 방지 
    {
        for(int i = 0; i < Guide_Tartgets.Length; i++)
        {
            Guide_Tartgets[i] = this.transform;
        }
    }
}
