using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using TMPro;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;
    NpcTalk_Window NW;

    private void Start()
    {
        Child_Start_Setting();
        NW = NpcTalk_Window.Inst;
    }

    public override void Outline_Active() // 아웃라인 적용
    {
        Body_Outline.SetActive(true);
    }

    public override void Outline_Unactive() // 아웃라인 해제
    {
        Body_Outline.SetActive(false);
    }

    public override void Connect_Window_Individual()
    {
        // 버튼 활성화 
        
        //0번 버튼
        NW.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 완료 1건";
        NW.Buttons[0].GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        //1번 버튼
        NW.Buttons[1].GetComponent<Image>().color = Color.gray;
        NW.Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = "퀘스트 신청";
        //Lock 활성화 -> 나중에 락이 풀리는 시기가 정해지면 아래 코드를 if문으로 조건 정해주기
        NW.Buttons[1].transform.GetChild(1).gameObject.SetActive(true);
    }

    void QuestComplete_Button()
    {
        //이벤트
        NW.Events[0].SetActive(true);
        NW.Events[0].GetComponent<Animator>().SetBool("Open", true);

        //보상 적용 -> 나중에 구현

        //Npc아이콘 비활성화
        I_Data.Npc_Icon.SetActive(false);
    }
}
