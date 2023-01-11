using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using TMPro;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;

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
        if(PQ.Progress.text == "완료")
        {
            //0번 버튼 -> 퀘스트 완료
            NpcTalk_Window.Inst.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 완료 보고";
            NpcTalk_Window.Inst.Buttons[0].GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        }
        
        //버튼 활성화
        NpcTalk_Window.Inst.Buttons[0].SetActive(true);
    }
    public override void Button1_Set(Proceeding_Quest PQ)
    {
        //1번 버튼
        NpcTalk_Window.Inst.Buttons[1].GetComponent<Image>().color = Color.gray;
        NpcTalk_Window.Inst.Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 신청";
        //Lock 활성화 -> 나중에 락이 풀리는 시기가 정해지면 아래 코드를 if문으로 조건 정해주기
        NpcTalk_Window.Inst.Buttons[1].transform.GetChild(1).gameObject.SetActive(true);
        //버튼 활성화
        NpcTalk_Window.Inst.Buttons[1].SetActive(true);
    }

    void QuestComplete_Button()
    {
        //이벤트
        NpcTalk_Window.Inst.Events[0].SetActive(true);
        NpcTalk_Window.Inst.Events[0].GetComponent<Animator>().SetBool("Open", true);

        //Npc아이콘 비활성화
        I_Data.Npc_Icon.SetActive(false);

        // 0번 버튼 비활성화
        NpcTalk_Window.Inst.Buttons[0].GetComponent<Button>().onClick.RemoveListener(QuestComplete_Button);
        NpcTalk_Window.Inst.Buttons[0].GetComponent<Image>().color = Color.gray;
    }
}
