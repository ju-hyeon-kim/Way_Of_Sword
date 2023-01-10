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
}
