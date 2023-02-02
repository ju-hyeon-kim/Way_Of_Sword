using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_SubWindow : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Explanation;
    public TMP_Text Progress;
    public TMP_Text Countig_Text;

    public Animator Quest_List_Anim;
    public TMP_Text PnM_Btn_Text;
    public GameObject[] Q_Exist_Settings;

    bool List_Down = true; // 초기: 리스트는 내려가 있다.
    Quest_Data nowQD;

    public void Change_Quest(Quest_Data QD)
    {
        nowQD = QD;
        Q_Exist_Settings[0].SetActive(false); // '현재 진행중인 퀘스트가...' 세팅
        Q_Exist_Settings[1].SetActive(true); // 기본세팅
        Name.text = nowQD.Name;
        Explanation.text = nowQD.Explanation;
        Progress.text = "진행중";
        Progress.color = Color.white;
        //Countig_Text
        if (nowQD.isCounting())
        {
            Countig_Text.text = $"({nowQD.Now_Count()}/{nowQD.Max_Count()})";
            Countig_Text.gameObject.SetActive(true);
        }
        else
        {
            Countig_Text.gameObject.SetActive(false);
        }
    }

    public void Complete_Quest() //퀘스트의 조건 충족 함수
    {
        Progress.text = "완료";
        Progress.color = Color.green;
    }

    public void None_Quest()
    {
        // 현재 진행중인 퀘스트가 없습니다.
        Q_Exist_Settings[0].SetActive(true);
        Q_Exist_Settings[1].SetActive(false);
    }

    public void List_UpDown() // PnM 버튼 함수
    {
        if (List_Down) // 리스트가 내려가있을 경우
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

    public void Add_KillCount(int count)
    {
        Countig_Text.text = $"({count}/{nowQD.Max_Count()})";
    }
}
