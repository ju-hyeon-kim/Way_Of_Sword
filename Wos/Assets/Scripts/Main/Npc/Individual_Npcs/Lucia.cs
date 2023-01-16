using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using TMPro;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;
    Proceeding_Quest PQ_Data;
    

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

    public override void Button0_Set(Proceeding_Quest PQ)
    {
        PQ_Data = PQ; // -> QuestComplete_Button()함수가 사용할 수 있게 멤버변수로 값을 받아둠

        if (PQ.Progress.text == "완료") //퀘스트가 완료 상태라면
        {
            //버튼에 온클릭 적용
            C_Data.NpcTalk_Window.Buttons[0].GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        }
        else // 진행중 상태라면
        {
            C_Data.NpcTalk_Window.Buttons[0].GetComponent<Image>().color = Color.gray; // 회색으로 보이게
        }

        //버튼 활성화
        C_Data.NpcTalk_Window.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 완료 보고";
        C_Data.NpcTalk_Window.Buttons[0].SetActive(true);
    }
    public override void Button1_Set(Proceeding_Quest PQ)
    {
        //1번 버튼
        C_Data.NpcTalk_Window.Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 신청";
        //Lock 활성화 -> 나중에 락이 풀리는 시기가 정해지면 아래 코드를 if문으로 조건 정해주기
        C_Data.NpcTalk_Window.Buttons[1].transform.GetChild(1).gameObject.SetActive(true);
        //온클릭 적용
        C_Data.NpcTalk_Window.Buttons[1].GetComponent<Button>().onClick.AddListener(QuestRequest_Btton);
        //버튼 활성화
        C_Data.NpcTalk_Window.Buttons[1].SetActive(true);
    }

    void QuestComplete_Button()
    {
        //이벤트에게 퀘스트 정보전달
        Quest_Complete QC = C_Data.NpcTalk_Window.Events[0].GetComponent<Quest_Complete>();
        QC.Q_Name.text = PQ_Data.Name.text;
        for(int i = 0; i < 3; i++) // 보상갯수에 맞게 보상슬롯 활성화
        {
            if(PQ_Data.Reward_Slots[i].activeSelf == true)
            {
                Instantiate(PQ_Data.Reward_Slots[i].transform.GetChild(0).GetChild(0).gameObject, QC.Q_Reword[i].transform.GetChild(0));
                QC.Q_Reword[i].SetActive(true);
            }
            else
            {
                QC.Q_Reword[i].SetActive(false);
            }
        }

        //이벤트 활성화
        C_Data.NpcTalk_Window.Events[0].SetActive(true);
        C_Data.NpcTalk_Window.Events[0].GetComponent<Animator>().SetBool("Open", true);

        //Npc아이콘 비활성화
        I_Data.Npc_Icon.SetActive(false);

        // 0번 버튼 비활성화
        C_Data.NpcTalk_Window.Buttons[0].GetComponent<Button>().onClick.RemoveListener(QuestComplete_Button);
        C_Data.NpcTalk_Window.Buttons[0].GetComponent<Image>().color = Color.gray;
    }

    void QuestRequest_Btton()
    {
        C_Data.NpcTalk_Window.Events[1].SetActive(true); // 리퀘스트 윈도우 생성
    }
}
