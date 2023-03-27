using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryTelling : MonoBehaviour
{
    public Manager_Story1 Manager_Story1;
    public TMP_Text Line;
    [TextArea]
    public string[] Lines; // 대사 모음

    int num = -1;

    public void Show_NextLine() // AnimEvent
    {
        Line.text = Lines[++num];
        if(num == 3)
        {
            GetComponent<Animator>().SetTrigger("OnOff");
            Manager_Story1.Start_Story1();
        }
    }
}
