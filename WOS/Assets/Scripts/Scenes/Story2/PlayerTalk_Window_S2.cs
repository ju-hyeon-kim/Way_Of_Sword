using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using TMPro;
using UnityEngine;

public class PlayerTalk_Window_S2 : MonoBehaviour
{
    public ReadyContent[] ReadyContents;
    public TMP_Text Talk;
    public GameObject NextIcon;
    public GameObject BenderTalk_Window;

    public bool TalkEnd = false;
    public bool SceneEnd = false;
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
                if (Content_Num == 3)
                {
                    SceneEnd = true;
                }
                else
                {
                    BenderTalk_Window.SetActive(true);
                    BenderTalk_Window.GetComponent<BenderTalk_Window_S2>().NextTalk();

                    ++Content_Num;
                    gameObject.SetActive(false);
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

    public void NextTalk()
    {
        StartCoroutine(Talking());
    }
}
