using UnityEngine;

public class Map_Window : MonoBehaviour
{
    public GameObject Forest_Lock;

    public void NowQuest_Check()
    {
        //0번째퀘스트가 클리어 되면 포레스트락이 꺼진다
        if (Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Quest_Number > 0)
        {
            Forest_Lock.SetActive(false);
        }
    }

    public void Exit_Button()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }


}
