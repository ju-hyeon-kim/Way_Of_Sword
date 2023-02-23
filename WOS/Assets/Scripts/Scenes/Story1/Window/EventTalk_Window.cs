using TMPro;
using UnityEngine;

[System.Serializable]
public class ReadyContent_Event
{
    [TextArea]
    public string Content;
}

public class EventTalk_Window : MonoBehaviour
{
    public ReadyContent_Event[] ReadyContents;
    public TMP_Text Talk;
}
