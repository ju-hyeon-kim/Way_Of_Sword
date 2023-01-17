using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk_Window : MonoBehaviour
{
    public GameObject[] Npc_Profiles;
    public GameObject[] Buttons;
    public TMP_Text[] myTMP_Texts; // 0=Name,1=Talk

    public Event_Window Event_Window;

    
    public MainCam_Controller MainCam;
    public GameObject Npc_Icon;
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
            myTMP_Texts[1].text = SaveString;
            yield return new WaitForSeconds(0.1f); // 0.1초당 한 글자 타이핑
        }
        //Save strings 초기화
        SaveText = "";
        SaveString = "";

        //버튼들 세팅
        Target_Npc.Buttons_Setting(Proceeding_Quest);
    }

    public void Lock_or_Unlock_Button(int i, bool b)
    {
        Buttons[i].transform.GetChild(1).gameObject.SetActive(b);
    }
}
