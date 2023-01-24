using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_0 : Quest_Data
{
    bool isComplete = false;

    public override bool isCounting()
    {
        return false;
    }

    public override void Start_Questing()
    {
        StartCoroutine(Questing());
    }

    IEnumerator Questing()
    {
        while (Quest_isStart)
        {
            if (SceneManager.GetActiveScene().name == "Guild") // ����Ʈ �Ϸ� ����
            {
                if(!isComplete)
                {
                    Manager_Quest.Inst.Complete_Quest();
                    isComplete = true;
                }
            }
            else
            {
                if(isComplete)
                {
                    //���̵� �ٽ� ����
                    Manager_Quest.Inst.Quest_Guide.StartGuiding();
                    isComplete = false;
                }
            }
            yield return null;
        }
    }
}
