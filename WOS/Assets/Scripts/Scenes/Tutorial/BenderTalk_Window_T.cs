using System.Collections;
using TMPro;
using UnityEngine;

public class BenderTalk_Window_T : MonoBehaviour
{
    public ReadyContent[] ReadyContents;
    public TMP_Text Talk;
    public GameObject NextIcon;

    public bool TalkEnd = false;
    public bool SceneEnd = false;
    public int Content_Num = 0;
    string TextTemp = "";

    Coroutine co;

    private void Update()
    {
        if (TalkEnd == true)
        {
            TextTemp = "";
            StopCoroutine(co);
            if (Input.anyKeyDown)
            {
                // 다음 스탭 넘어가기
                ++Content_Num;
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
        co = StartCoroutine(Talking());
    }
}
