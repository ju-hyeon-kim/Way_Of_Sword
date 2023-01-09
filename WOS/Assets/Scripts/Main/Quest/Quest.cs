using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
{
    public TMP_Text Progress;

    bool Quest_Complete = false;

    private void Start()
    {
        StartCoroutine(Questing());
    }

    IEnumerator Questing()
    {
        while (!Quest_Complete)
        {
            if(SceneManager.GetActiveScene().name == "Guild")
            {
                Progress.text = "¿Ï·á";
                Progress.color = Color.green;
                Quest_Complete = true;
            }
            yield return null;
        }
    }
}
