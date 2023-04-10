using System.Collections;
using TMPro;
using UnityEngine;

public class NpcTalk_Window : MonoBehaviour
{
    public AudioClip[] TypingSounds;
    public GameObject[] Npc_Profiles;
    public GameObject[] Buttons;
    public TMP_Text[] myTMP_Texts; // 0=Name,1=Talk

    public Event_Window Event_Window;
    public AudioSource myAudioSource;

    public MainCam_Controller MainCam;
    public Proceeding_Quest Proceeding_Quest;

    string SaveText = "";
    string SaveString = "";

    public void Talking(Npc Target_Npc)
    {
        SaveText = Target_Npc.Greetings;
        StartCoroutine(Typing(Target_Npc));
    }

    IEnumerator Typing(Npc Target_Npc)
    {
        for (int i = 0; i < SaveText.Length; ++i)
        {
            SaveString += SaveText[i];
            myTMP_Texts[1].text = SaveString;

            //타이핑 사운드
            int rnd = Random.Range(0, 2);
            myAudioSource.clip = TypingSounds[rnd];
            myAudioSource.Play();
            yield return new WaitForSeconds(0.1f); // 0.1초당 한 글자 타이핑
        }
        //Save strings 초기화
        SaveText = "";
        SaveString = "";

        //버튼들 세팅
        Target_Npc.Buttons_Setting();
    }

    public void Lock_or_Unlock_Button(int i, bool b)
    {
        Buttons[i].transform.GetChild(1).gameObject.SetActive(b);
    }
}
