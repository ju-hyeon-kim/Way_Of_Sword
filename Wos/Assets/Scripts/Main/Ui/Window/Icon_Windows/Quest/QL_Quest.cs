using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class QL_Quest : MonoBehaviour
{
    public Quest_Data Quest_Data;

    public TMP_Text Q_Name;
    public GameObject[] Q_Reword;
    public GameObject Lock;
    public GameObject State;
    public GameObject Complete;

    public void Complete_Quest()
    {
        State.SetActive(false);
        Complete.SetActive(true);
    }

    public void UnLock_Quest()
    {
        //����Ʈ �̸�
        Q_Name.text = Quest_Data.Name;
        Q_Name.fontSize = 18f;
        //���� ����
        for(int i = 0; i < 3; i++)
        {
            // ����Ʈ�� ���� ������ŭ ���󽽷� Ȱ��ȭ
            if (i >= Quest_Data.Reward.Length)
            {
                Q_Reword[i].SetActive(false);
            }
            else
            {
                Instantiate(Quest_Data.Reward[i], Q_Reword[i].transform.GetChild(1)); // Icon_Area�� �ڽ����� ������ ������Ʈ ����
            }
        }
        //"���డ��"
        State.SetActive(true);

        //Lock ����
        Lock.SetActive(false);
    }
}
