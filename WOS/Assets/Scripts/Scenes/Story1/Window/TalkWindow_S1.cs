using System.Collections;
using TMPro;
using UnityEngine;

public class TalkWindow_S1 : MonoBehaviour
{
    public Manager_Story1 Manager;
    [TextArea]
    public string[] Lines_ofPlayer;
    [Multiline]
    public string[] Lines_ofShouter;
    public TMP_Text Line;
    public GameObject NextIcon;
    public SpeechBubble SpeechBubble;

    int PNum = 0;
    bool TalkEnd = false;

    private void Update()
    {
        if (TalkEnd == true) // ��簡 �������� ��ġ�ؼ� �������� �ѱ��.
        {
            if (Input.GetMouseButtonDown(0) && PNum < Lines_ofPlayer.Length-1) // Ŭ������ ������� �Ѿ��
            {
                if(PNum == 2) // ��
                {
                    Manager.ChangeStep(STEP.Sword);
                    this.gameObject.SetActive(false);
                }
                else
                {
                    PNum++;
                    StartCoroutine(Typing());
                }
            }
        }
    }
    public void StartTalking()
    {
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        Line.text = "";

        TalkEnd = false;
        NextIcon.SetActive(false);

        for (int i = 0; i < Lines_ofPlayer[PNum].Length; ++i)
        {
            Line.text += Lines_ofPlayer[PNum][i];
            yield return new WaitForSeconds(0.1f);
        }

        /*if (PNum == 2 || PNum == 3)
        {
            SpeechBubble.ShoutAnim(Lines_ofShouter[SNum], SNum);
            yield return new WaitUntil(SpeechBubble.Get_isEndAnim);
            SNum++;
            PNum++;
            StartCoroutine(Typing());
        }*/

        NextIcon.SetActive(true);
        TalkEnd = true;
    }
}
