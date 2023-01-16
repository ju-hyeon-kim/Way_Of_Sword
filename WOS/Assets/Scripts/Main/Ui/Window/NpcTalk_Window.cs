using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk_Window : MonoBehaviour
{
    public GameObject[] Npc_Profiles;
    public GameObject[] Buttons;
    public GameObject[] Events;

    public TMP_Text Name;
    public TMP_Text Talk;
    public MainCam_Controller MainCam;
    public GameObject Npc_Icon;
    public Quest_SubWindow Quest_SubWindow;
    public Proceeding_Quest Proceeding_Quest;

    public string SaveText = "";
    string SaveString = "";

    public void Talking(Npc Target_Npc)
    {
        StartCoroutine(Typing(Target_Npc));
    }

    IEnumerator Typing(Npc Target_Npc)
    {
        for (int i = 0; i < SaveText.Length; ++i)
        {
            SaveString += SaveText[i];
            Talk.text = SaveString;
            yield return new WaitForSeconds(0.1f); // 0.1초당 한 글자 타이핑
        }
        //Save strings 초기화
        SaveText = "";
        SaveString = "";

        //버튼들 세팅
        Target_Npc.Buttons_Setting(Proceeding_Quest);
    }

    public void Unlock_Button(int i)
    {
        Buttons[i].transform.GetChild(1).gameObject.SetActive(false);
    }
}
