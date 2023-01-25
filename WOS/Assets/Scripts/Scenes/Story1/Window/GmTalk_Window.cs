using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ReadyContent_GM
{
    [TextArea]
    public string Content;
}

public class GmTalk_Window : MonoBehaviour
{
    public ReadyContent_GM[] ReadyContents;
    public TMP_Text Talk;

    public int Content_Num = 0;

    public void NextTalk()
    {
        Talk.text = ReadyContents[Content_Num].Content;
    }
}