using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using TMPro;
using UnityEngine;


[System.Serializable]
public class ReadyContent
{
    [TextArea]
    public string Content;
}

public class BenderTalk_Window_S2 : MonoBehaviour
{
    public ReadyContent[] ReadyContents;
    public TMP_Text Talk;
    public GameObject NextIcon;

    public bool TalkEnd = false;
    public int Content_Num = 0;
    string TextTemp = "";

    IEnumerator Coroutine;

    private void Start()
    {
        Coroutine = Talking();
    }

    private void Update()
    {
        if (TalkEnd == true)
        {
            TextTemp = "";
            StopCoroutine(Coroutine);
            if (Input.anyKeyDown)
            {
                Content_Num++;
                // NextTalk()는 스탭이 넘어갈땐 실행 안되게
                NextTalk();
            }
        }
    }

    IEnumerator Talking()
    {
        TalkEnd = false;
        NextIcon.SetActive(false);

        for (int i = 0; i < ReadyContents[Content_Num].Content.Length; ++i)
        {
            TextTemp += ReadyContents[Content_Num].Content[i];
            Talk.text = TextTemp;
            yield return new WaitForSeconds(0.1f);
        }
        NextIcon.SetActive(true);
        TalkEnd = true;
    }

    public void NextTalk()
    {
        StartCoroutine(Talking());
    }
}
