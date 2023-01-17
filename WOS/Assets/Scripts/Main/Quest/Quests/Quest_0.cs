using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_0 : Quest_Data
{
    bool Quest_Complete = false;

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
        while (!Quest_Complete)
        {
            if (SceneManager.GetActiveScene().name == "Guild")
            {
                transform.parent.GetComponent<Manager_Quest>().Complete_Quest();
                Quest_Complete = true;
            }
            yield return null;
        }
    }
}
