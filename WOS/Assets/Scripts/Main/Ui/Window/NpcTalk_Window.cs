using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk_Window : MonoBehaviour
{
    #region 싱글톤 세팅 + Awake()
    private static NpcTalk_Window Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
    }

    public static NpcTalk_Window Inst
    {
        get
        {
            if (Instence == null) // 다른 오브젝트의 Awake()에서 Inst를 호출할 경우
            {
                return null;
            }
            return Instence;
        }
    }
    #endregion

    public GameObject[] Npc_Profiles;
    public GameObject[] Buttons;
    public GameObject[] Events;

    public TMP_Text Name;
    public TMP_Text Talk;
    public MainCam_Controller MainCam;
    public GameObject Lock;
    public GameObject Messages;
    public Image XP_Bar;
    public TMP_Text XP_Readings;
    public GameObject Npc_Icon = null;
    public Quest_SubWindow Quest_SubWindow;

    public string SaveText = "";
    string SaveString = "";
    string Target_Npc = "";

    private void Start()
    {
        for(int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void Talking(string Npc_Name)
    {
        Target_Npc = Npc_Name;
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
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

        //버튼 활성화
        for(int i = 0; i < Buttons.Length; i++)
        {
            
            switch(Target_Npc)
            {
                case "벤더":
                    i = 2; // 돌아가기 버튼만 활성화
                    break;
                case "루시아":
                    //루시아 버튼 세팅
                    Lucia_Setting();
                    break;
            }
            Buttons[i].SetActive(true); // 돌아가기 버튼 활성화는 공통
        }
    }

    public void On_GobackButton()
    {
        //버튼 비활성화
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].SetActive(false);
        }
        this.gameObject.SetActive(false);
        // 카메라 시점 원래대로
        MainCam.ReturnView();
    }

    void Lucia_Setting()
    {
        //0번 버튼
        Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 완료 1건";
        Buttons[0].GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        //1번 버튼
        Buttons[1].GetComponent<Image>().color = Color.gray;
        Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 신청";
        Lock.SetActive(true);
    }

    void QuestComplete_Button()
    {
        Events[0].SetActive(true);
        //애니메이션
        Events[0].GetComponent<Animator>().SetBool("Open", true);
        //보상 적용
        Messages.SetActive(true);
        XP_Bar.fillAmount = 0;
        XP_Bar.fillAmount += 50.0f * 0.01f;
        XP_Readings.text = "(50/100)";
        //Npc아이콘 비활성화
        Npc_Icon.SetActive(false);
        //퀘스트 서브 윈도우 적용
        Quest_SubWindow.Quest_Remove(0);
    }
}
