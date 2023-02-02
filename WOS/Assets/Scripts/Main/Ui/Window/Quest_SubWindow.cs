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

    bool List_Down = true; // �ʱ�: ����Ʈ�� ������ �ִ�.
    Quest_Data nowQD;

    public void Change_Quest(Quest_Data QD)
    {
        nowQD = QD;
        Q_Exist_Settings[0].SetActive(false); // '���� �������� ����Ʈ��...' ����
        Q_Exist_Settings[1].SetActive(true); // �⺻����
        Name.text = nowQD.Name;
        Explanation.text = nowQD.Explanation;
        Progress.text = "������";
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

    public void Complete_Quest() //����Ʈ�� ���� ���� �Լ�
    {
        Progress.text = "�Ϸ�";
        Progress.color = Color.green;
    }

    public void None_Quest()
    {
        // ���� �������� ����Ʈ�� �����ϴ�.
        Q_Exist_Settings[0].SetActive(true);
        Q_Exist_Settings[1].SetActive(false);
    }

    public void List_UpDown() // PnM ��ư �Լ�
    {
        if (List_Down) // ����Ʈ�� ���������� ���
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
