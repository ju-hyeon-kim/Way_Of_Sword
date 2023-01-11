using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_0 : Quest_Data
{
    bool Quest_Complete = false;

    public override void Start_Questing()
    {
        StartCoroutine(Questing());
    }

    IEnumerator Questing()
    {
        while (!Quest_Complete)
        {
            if (SceneManager.GetActiveScene().name == "Guild")
            {
                // ������ -> �Ϸ� (+����->�ʷ�)
                transform.parent.GetComponent<Manager_Quest>().Proceeding_Quest.Progress.text = "�Ϸ�";
                transform.parent.GetComponent<Manager_Quest>().Proceeding_Quest.Progress.color = Color.green;
                transform.parent.GetComponent<Manager_Quest>().Update_SubWindow(GetComponent<Quest_Data>());
                Quest_Complete = true;
            }
            yield return null;
        }
    }
}
