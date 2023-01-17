using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using TMPro;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;
    Proceeding_Quest nowPQ;

    private void Start()
    {
        Child_Start_Setting();
    }

    public override void Outline_Active() // 아웃라인 적용
    {
        Body_Outline.SetActive(true);
    }

    public override void Outline_Unactive() // 아웃라인 해제
    {
        Body_Outline.SetActive(false);
    }

    enum Q_STATE
    {
        Questing, Complete, None 
    }
    
    Q_STATE Q_state = Q_STATE.None;

    public override void Button_0and1_Set(Proceeding_Quest PQ) // 퀘스트의 상태를 감지
    {
        nowPQ = PQ;
        if (nowPQ.isQuesting_Obj[1].activeSelf == true)
        {
            if(nowPQ.Progress.text == "진행중")
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

    public void Button0_Set()
    {
        Transform myButton = C_Data.NpcTalk_Window.Buttons[0].transform;
        // 버튼 이름
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "완료된 퀘스트 없음";
        //Lock 활성화
        myButton.GetChild(1).gameObject.SetActive(true);
        //온클릭 적용
        myButton.GetComponent<Button>().onClick.AddListener(QuestComplete_Button);

        if(Q_state== Q_STATE.Complete) 
        {
            myButton.GetChild(1).gameObject.SetActive(false);
            myButton.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 완료 보고";
        }

        //버튼 활성화
        myButton.gameObject.SetActive(true);
    }

    public void Button1_Set()
    {
        Transform myButton = C_Data.NpcTalk_Window.Buttons[1].transform;
        // 버튼 이름
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 신청";
        //Lock 활성화
        myButton.GetChild(1).gameObject.SetActive(true);
        //온클릭 적용
        myButton.GetComponent<Button>().onClick.AddListener(QuestRequest_Btton);

        if(Q_state == Q_STATE.None) // 현재 퀘스트가 없다면 = 새로운 퀘스트를 받으러 왔다면
        {
            //Lock 비활성화
            myButton.GetChild(1).gameObject.SetActive(false);
        }

        //버튼 활성화
        myButton.gameObject.SetActive(true);
    }

    void QuestComplete_Button()
    {
        //이벤트에게 퀘스트 정보전달
        Quest_Complete QC = C_Data.NpcTalk_Window.Event_Window.Events[0].GetComponent<Quest_Complete>();

        QC.Q_Name.text = nowPQ.Name.text;
        for(int i = 0; i < 3; i++) // 보상갯수에 맞게 보상슬롯 활성화
        {
            if(nowPQ.Reward_Slots[i].activeSelf == true)
            {
                Instantiate(nowPQ.Reward_Slots[i].transform.GetChild(0).GetChild(0).gameObject, QC.Q_Reword[i].transform.GetChild(0));
                QC.Q_Reword[i].SetActive(true);
            }
            else
            {
                QC.Q_Reword[i].SetActive(false);
            }
        }

        //이벤트 활성화
        QC.gameObject.SetActive(true);
        QC.transform.GetComponent<Animator>().SetBool("Open", true);

        //Npc아이콘 비활성화
        I_Data.Npc_Icon.SetActive(false);

        // 0번 버튼 비활성화
        C_Data.NpcTalk_Window.Buttons[0].GetComponent<Button>().onClick.RemoveListener(QuestComplete_Button);
        C_Data.NpcTalk_Window.Buttons[0].GetComponent<Image>().color = Color.gray;
    }

    void QuestRequest_Btton()
    {
        C_Data.NpcTalk_Window.Event_Window.Events[1].SetActive(true); // 리퀘스트 윈도우 생성
    }
}
