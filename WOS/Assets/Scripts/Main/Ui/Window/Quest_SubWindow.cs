using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_SubWindow : MonoBehaviour
{
    public List<GameObject> QuestList = new List<GameObject>();
    public Animator Quest_List_Anim;
    public TMP_Text PnM_Btn_Text;
    bool List_Down = true; // �ʱ�: ����Ʈ�� ������ �ִ�.


    public void List_UpDown() // PnM ��ư �Լ�
    {
        if(List_Down) // ����Ʈ�� ���������� ���
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
