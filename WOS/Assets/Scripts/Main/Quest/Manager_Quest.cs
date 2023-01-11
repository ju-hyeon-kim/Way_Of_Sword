using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Quest : MonoBehaviour // ������ ����Ʈ ������, ���� ������ ����
{
    public Quest_Data[] QuestList; // ����Ʈ��
    public Proceeding_Quest Proceeding_Quest;
    public Quest_SubWindow Quest_SubWindow;


    private void Awake()
    {
        DontDestroyOnLoad(this); // ����ȯ �� �ı����� ����
    }

    private void Start()
    {
        //0��° ����Ʈ ����
        Instantiate(QuestList[0],transform);
        Quest_Data QD = transform.GetChild(0).GetComponent<Quest_Data>();

        //����Ʈ�� ������ ������ ����Ʈ �����쿡 ����
        Update_ProceedingQuest(QD);

        //����Ʈ�� ������ ���� �����쿡 ����
        Update_SubWindow(QD);

        //������ �ڷ�ƾ ���� ( ������/�Ϸ� ���θ� ���� )
        QD.Start_Questing();
    }

    public void Update_ProceedingQuest(Quest_Data QD) 
    {
        Proceeding_Quest.Name.text = QD.Name;
        Proceeding_Quest.Explanation.text = QD.Explanation;
        // ����Ʈ �������� ������ ���󽽷Կ� ����
        for (int i = 0; i < QD.Reward.Count; i++)
        {
            Proceeding_Quest.Reward_Slots[i].transform.GetChild(i).GetComponent<Image>().sprite = QD.Reward[i].Image;
        }
        // ������ ������ �°� �������� ���� ������ ������ �޶���
        for (int i = QD.Reward.Count; i < Proceeding_Quest.Reward_Slots.Length; i++)
        {
            Proceeding_Quest.Reward_Slots[i].SetActive(false);
        }
    }

    public void Update_SubWindow(Quest_Data QD)
    {
        Quest_SubWindow.Name.text = QD.Name;
        Quest_SubWindow.Explanation.text = QD.Explanation;
        Quest_SubWindow.Progress.text =  Proceeding_Quest.Progress.text;
        Quest_SubWindow.Progress.color = Proceeding_Quest.Progress.color;
    }
}
