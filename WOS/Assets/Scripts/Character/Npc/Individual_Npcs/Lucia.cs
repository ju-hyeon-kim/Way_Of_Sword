using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;
    Proceeding_Quest nowPQ;

    private void Start()
    {
        Child_Start_Setting();
    }

    public override void Outline_SetActive(bool b) // 아웃라인 적용
    {
        Body_Outline.SetActive(b);
    }

    enum Q_STATE
    {
        Questing, Complete, None
    }

    Q_STATE Q_state = Q_STATE.None;

    public override void Button0and1_ofChild() 
    {
        // 퀘스트의 상태를 감지
        nowPQ = Dont_Destroy_Data.Inst.Manager_Quest.Proceeding_Quest;
        if (nowPQ.Q_Exist_Settings[1].activeSelf == true)
        {
            if (nowPQ.Progress.text == "진행중")
            {
                //현재 퀘스트가 조건 불충족 상태일 때 -> 아직 퀘스트 진행중
                Q_state = Q_STATE.Questing;
            }
            else
            {
                //현재 퀘스트가 조건 충족 상태일 때 -> 완료 보고를 하러 왔을 때
                Q_state = Q_STATE.Complete;
            }
        }
        else
        {
            //현재 퀘스트가 없을 때 -> 퀘스트를 신청 하러 왔을 때
            Q_state = Q_STATE.None;
        }
        Button0_Set();
        Button1_Set();
    }

    void Button0_Set()
    {
        Transform myButton = NpcTalk_Window.Buttons[0].transform;
        // 버튼 이름
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "완료된 퀘스트 없음";
        //Lock 활성화
        myButton.GetChild(1).gameObject.SetActive(true);
        //온클릭 적용
        myButton.GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        myButton.GetComponent<Button>().onClick.AddListener(Play_ClickSound);

        if (Q_state == Q_STATE.Complete)
        {
            myButton.GetChild(1).gameObject.SetActive(false);
            myButton.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 완료 보고";
        }

        //버튼 활성화
        myButton.gameObject.SetActive(true);
    }

    void Button1_Set()
    {
        Transform myButton = NpcTalk_Window.Buttons[1].transform;
        // 버튼 이름
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 신청";
        //Lock 활성화
        myButton.GetChild(1).gameObject.SetActive(true);
        //온클릭 적용
        myButton.GetComponent<Button>().onClick.AddListener(QuestRequest_Btton);
        myButton.GetComponent<Button>().onClick.AddListener(Play_ClickSound);

        if (Q_state == Q_STATE.None) // 현재 퀘스트가 없다면 = 새로운 퀘스트를 받으러 왔다면
        {
            //Lock 비활성화
            myButton.GetChild(1).gameObject.SetActive(false);
        }

        //버튼 활성화
        myButton.gameObject.SetActive(true);
    }

    void QuestComplete_Button()
    {
        //Quest_Complete에게 퀘스트 정보전달
        Quest_Complete QC = NpcTalk_Window.Event_Window.Events[0].GetComponent<Quest_Complete>();

        QC.Q_Name.text = nowPQ.Name.text;
        Quest_Data nowQD = Dont_Destroy_Data.Inst.Manager_Quest.NowQuest;
        int RewardCount = nowQD.Reward.Length;

        for (int i = 0; i < 3; i++)
        {
            if (i < RewardCount)
            {
                GameObject Obj = Instantiate(nowQD.Reward[i], QC.Q_Reword[i].transform) as GameObject;
                Obj.transform.SetAsFirstSibling();
                QC.Q_Reword[i].SetActive(true);
            }
            else
            {
                QC.Q_Reword[i].SetActive(false);
            }
        }
        //sfx
        //Manager_Sound.Inst.SfxSource.OnPlay(11);

        //이벤트 활성화
        QC.gameObject.SetActive(true);
        QC.transform.GetComponent<Animator>().SetBool("Open", true);

        // 0번 버튼 Lock 적용
        NpcTalk_Window.Lock_or_Unlock_Button(0, true);
        NpcTalk_Window.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "완료된 퀘스트 없음";
    }

    void QuestRequest_Btton()
    {
        NpcTalk_Window.Event_Window.Events[1].SetActive(true); // 리퀘스트 윈도우 생성
    }

    public override void Child_Reaction()
    {
        //사운드
        GetComponent<AudioSource>().Play();
    }
}