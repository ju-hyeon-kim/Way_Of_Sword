using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_1 : Quest_Data
{
    public void startco()
    {
        StartCoroutine(test());
    }

    bool Quest_Complete = false;



    IEnumerator test()
    {
        bool b = true;
        while (b)
        {
            Debug.Log("실행중");
            b = false;
            yield return null;
        }
    }

    /*public void CoQ()
    {
        StartCoroutine(Questing());
    }*/

    /*IEnumerator Questing()
    {
        while (!Quest_Complete)
        {
            if(SceneManager.GetActiveScene().name == "Guild")
            {
                Progress.text = "완료";
                Progress.color = Color.green;
                Quest_Complete = true;
            }
            yield return null;
        }
    }*/
}
