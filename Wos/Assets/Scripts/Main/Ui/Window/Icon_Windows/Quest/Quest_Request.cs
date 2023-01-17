using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_Request : MonoBehaviour
{
    public TMP_Text Q_Name;
    public TMP_Text Q_Explanation;
    public GameObject[] Q_Reword;
    public Manager_Quest Manager_Quest;
    public NpcTalk_Window NpcTalk_Window;

    Quest_Data myQD;

    public void Accept_Button() // ���� ��ư
    {
        Manager_Quest.Change_NowQuest();
        NpcTalk_Window.Lock_or_Unlock_Button(1, true); //����Ʈ ��û ��ư Lock ����
        gameObject.SetActive(false);
    }

    public void Recept_Button() // ���� ��ư
    {
        gameObject.SetActive(false);
    }

    public void Input_Quest_Data(Quest_Data QD) // ����Ʈ ������ �Է�
    {
        myQD = QD;

        Q_Name.text = myQD.Name;
        Q_Explanation.text = myQD.Explanation;

        // ����Ʈ �������� ������ ���󽽷Կ� ����
        for (int i = 0; i < myQD.Reward.Count; i++)
        {
            Instantiate(myQD.Reward[i], Q_Reword[i].transform.GetChild(0));
        }
        // ������ ������ �°� �������� ���� ������ ������ �޶���
        for (int i = myQD.Reward.Count; i < Q_Reword.Length; i++)
        {
            Q_Reword[i].SetActive(false);
        }
    }
}
