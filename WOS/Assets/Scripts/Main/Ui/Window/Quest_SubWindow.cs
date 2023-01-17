using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_SubWindow : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Explanation;
    public TMP_Text Progress;

    public Animator Quest_List_Anim;
    public TMP_Text PnM_Btn_Text;
    public GameObject[] isQuesting_Obj;

    bool List_Down = true; // 초기: 리스트는 내려가 있다.

    public void Update_Window(Quest_Data QD, bool Quest_Exist, bool isQuesting)
    {
        isQuesting_Obj[0].SetActive(false); // 기본 세팅
        isQuesting_Obj[1].SetActive(true); // '현재 진행중인 퀘스트가...' 세팅
        Name.text = QD.Name;
        Explanation.text = QD.Explanation;

        if (isQuesting) // 퀘스팅 코루틴이 구동중일 때
        {
            Progress.text = "진행중";
            Progress.color = Color.white;
        }
        else // 퀘스팅 코루틴 구동중지 => 퀘스트 완료 조건 충족 -> 퀘스트의 조건 충족 함수 구현 필요
        {
            Progress.text = "완료";
            Progress.color = Color.green;
        }

    }

    public void List_UpDown() // PnM 버튼 함수
    {
        if(List_Down) // 리스트가 내려가있을 경우
        {
            List_Down = false;
            Quest_List_Anim.SetBool("UpDown", true);
            PnM_Btn_Text.text = "+";
        }
        else
        {
            List_Down = true;
            Quest_List_Anim.SetBool("UpDown", false);
            PnM_Btn_Text.text = "-";
        }
    }

    public void Quest_Complete()
    {
        // 현재 진행중인 퀘스트가 없습니다.
        isQuesting_Obj[0].SetActive(true);
        isQuesting_Obj[1].SetActive(false);
    }

    //퀘스트의 조건 충족 함수 구현 필요
}
