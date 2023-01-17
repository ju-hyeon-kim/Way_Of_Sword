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

    bool List_Down = true; // �ʱ�: ����Ʈ�� ������ �ִ�.

    public void Update_Window(Quest_Data QD, bool Quest_Exist, bool isQuesting)
    {
        isQuesting_Obj[0].SetActive(false); // �⺻ ����
        isQuesting_Obj[1].SetActive(true); // '���� �������� ����Ʈ��...' ����
        Name.text = QD.Name;
        Explanation.text = QD.Explanation;

        if (isQuesting) // ������ �ڷ�ƾ�� �������� ��
        {
            Progress.text = "������";
            Progress.color = Color.white;
        }
        else // ������ �ڷ�ƾ �������� => ����Ʈ �Ϸ� ���� ���� -> ����Ʈ�� ���� ���� �Լ� ���� �ʿ�
        {
            Progress.text = "�Ϸ�";
            Progress.color = Color.green;
        }

    }

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

    public void Quest_Complete()
    {
        // ���� �������� ����Ʈ�� �����ϴ�.
        isQuesting_Obj[0].SetActive(true);
        isQuesting_Obj[1].SetActive(false);
    }

    //����Ʈ�� ���� ���� �Լ� ���� �ʿ�
}
