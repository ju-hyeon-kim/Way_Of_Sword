using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Window : MonoBehaviour
{
    public GameObject Forest_Lock;
    
    public void NowQuest_Check()
    {
        //0��°����Ʈ�� Ŭ���� �Ǹ� ������Ʈ���� ������
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
