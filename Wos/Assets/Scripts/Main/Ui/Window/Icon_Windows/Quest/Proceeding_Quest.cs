using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Proceeding_Quest : MonoBehaviour
{
    public TMP_Text Name;
    public TMP_Text Explanation;
    public TMP_Text Progress;
    public TMP_Text Countig_Text;
    public GameObject[] Reward_Slots;
    public GameObject[] Q_Exist_Settings; // ���� ����Ʈ�� �����ϴ��� ���ϴ����� ���� �޶����� ���ð�

    public void Change_Quest(Quest_Data QD)
    {
        Q_Exist_Settings[0].SetActive(false);
        Q_Exist_Settings[1].SetActive(true);

        Name.text = QD.Name;
        Explanation.text = QD.Explanation;
        // ����Ʈ �������� ������ ���󽽷Կ� ����
        for (int i = 0; i < QD.Reward.Count; i++)
        {
            Instantiate(QD.Reward[i], Reward_Slots[i].transform.GetChild(0));
        }
        // ������ ������ �°� �������� ���� ������ ������ �޶���
        for (int i = QD.Reward.Count; i < Reward_Slots.Length; i++)
        {
            Reward_Slots[i].SetActive(false);
        }
        Progress.text = "������";
        Progress.color = Color.white;
        //ī��Ʈ�� ���� ����Ʈ���� �˻�
        if(QD.isCounting())
        {
            Countig_Text.text = $"({QD.Now_Count()}/{QD.Max_Count()})";
            Countig_Text.gameObject.SetActive(true);
        }
        else
        {
            Countig_Text.gameObject.SetActive(false);
        }
    }

    public void Complete_Quest()
    {
        Progress.text = "�Ϸ�";
        Progress.color = Color.green;
    }

    public void None_Quest()
    {
        Q_Exist_Settings[0].SetActive(true);
        Q_Exist_Settings[1].SetActive(false);
    }
}
