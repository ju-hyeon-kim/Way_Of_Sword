using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerTalk_Window_S1 : MonoBehaviour
{
    public ReadyContent[] ReadyContents;
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
                if (Content_Num == 3)
                {
                    //���丮 �Ŵ����� Event2�� ����ü����
                    Step_Event2 = true;
                }
                else if (Content_Num == 4)
                {
                    Step_Move2 = true;
                }
                else
                {
                    Content_Num++;
                    // NextTalk()�� ������ �Ѿ�� ���� �ȵǰ�
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
