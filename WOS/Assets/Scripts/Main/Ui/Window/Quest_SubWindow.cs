using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_SubWindow : MonoBehaviour
{
    public Animator Quest_List;
    public TMP_Text PnM_Btn_Text;
    bool List_Down = true; // �ʱ�: ����Ʈ�� ������ �ִ�.


    public void List_UpDown() // PnM ��ư �Լ�
    {
        if(List_Down) // ����Ʈ�� ���������� ���
        {
            List_Down = false;
            Quest_List.SetBool("UpDown", true);
            PnM_Btn_Text.text = "+";
        }
        else
        {
            List_Down = true;
            Quest_List.SetBool("UpDown", false);
            PnM_Btn_Text.text = "-";
        }
    }
}
