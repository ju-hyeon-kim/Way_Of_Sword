using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using TMPro;
using UnityEngine;


[System.Serializable]
public class ReadyContent_Player
{
    [TextArea]
    public string Content;
}

public class PlayerTalk_Window : MonoBehaviour
{
    public ReadyContent_Player[] ReadyContents;
    public TMP_Text Talk;
    public GameObject NextIcon;
    public bool TalkEnd = false;
    public bool Step_Event2 = false;
    public bool Step_Move2 = false;
    public int Content_Num = 0;
    

    string TextTemp = "";
    IEnumerator Coroutine;

    private void Start()
    {
        Coroutine = Talking();
    }

    private void Update()
    {
        //if (TalkEnd == true && Content_Num < ReadyContents.Length)
        if (TalkEnd == true)
        {
            TextTemp = "";
            StopCoroutine(Coroutine);

            if (Input.anyKeyDown)
            {
                if(Content_Num == 3)
                {
                    //스토리 매니저의 Event2로 스탭체인지
                    Step_Event2 = true;
                }
                else if(Content_Num == 4)
                {
                    Step_Move2 = true;
                }
                else
                {
                    Content_Num++;
                    // NextTalk()는 스탭이 넘어갈땐 실행 안되게
                    if (Content_Num < ReadyContents.Length)
                    {
                        StartCoroutine(Talking());
                    }
                }
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

    public void CoTalking()
    {
        StartCoroutine(Talking());
    }
}
