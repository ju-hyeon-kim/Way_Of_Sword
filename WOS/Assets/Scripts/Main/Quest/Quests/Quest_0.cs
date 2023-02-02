using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_0 : Quest_Data
{
    bool isComplete = false;
    Manager_Quest MQ;

    public override bool isCounting()
    {
        return false;
    }

    public override void Start_Questing()
    {
        MQ = Dont_Destroy_Data.Inst.Manager_Quest;
        StartCoroutine(Questing());
    }

    IEnumerator Questing()
    {
        while (Quest_isStart)
        {
            if (SceneManager.GetActiveScene().name == "Guild") // 퀘스트 완료 조건
            {
                if(!isComplete)
                {
                    MQ.Complete_Quest();
                    isComplete = true;
                }
            }
            else
            {
                if(isComplete)
                {
                    //가이딩 다시 시작
                    MQ.Quest_Guide.StartGuiding();
                    isComplete = false;
                }
            }
            yield return null;
        }
    }
}
