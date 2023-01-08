using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_SubWindow : MonoBehaviour
{
    public List<GameObject> QuestList = new List<GameObject>();
    public Animator Quest_List_Anim;
    public TMP_Text PnM_Btn_Text;
    bool List_Down = true; // 초기: 리스트는 내려가 있다.


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

    public void Quest_Remove(int qNum)
    {
        QuestList[qNum].SetActive(false);
    }
}
