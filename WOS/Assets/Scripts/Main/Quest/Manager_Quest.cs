using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Quest : MonoBehaviour
{
    public Proceeding_Quest Proceeding_Quest;
    public Quest_SubWindow Quest_SubWindow;
    public Quest_List Quest_List;
    public Quest_Data[] Quest_Prefabs;
    public Quest_Request Quest_Request;
    public int Quest_Num = 0;
    Quest_Data NowQuest;


    private void Start()
    {
        Instantiate(Quest_Prefabs[Quest_Num], transform);
        NowQuest = transform.GetChild(0).GetComponent<Quest_Data>();

        //Quest List�� Po_Qeusts[0] Ȱ��ȭ
        Conect_Qeust_List();

        //Proceeding_Quest�� ����
        Conect_Proceeding_Quest();

        //Quest_SubWindow�� ����
        Conect_SubWindow(true);

        //������ ����
        OnStart_Questing();
    }

    public void Change_NowQuest()
    {
        if (transform.childCount > 0) // �Ŵ������� �ڽ��� �ִٸ� = ������ ����Ʈ�� �����Ǿ��ִٸ�
        {
            Destroy(transform.GetChild(0).gameObject); // �ش� ����Ʈ �ı�
        }
        Instantiate(Quest_Prefabs[Quest_Num], transform);
        NowQuest = transform.GetChild(0).GetComponent<Quest_Data>();
    }

    public void OnStart_Questing()
    {
        GetComponentInChildren<Quest_Data>().Start_Questing();
    }

    public void Conect_Qeust_List()
    {
        QL_Quest QLQ = Quest_List.QL_Quests[Quest_Num];
        QLQ.Q_Name.text = NowQuest.Name;
        QLQ.Q_Name.fontSize = 20f;
        QLQ.State.SetActive(true);

        for (int i = 0; i < QLQ.Q_Reword.Length; i++)
        {
            if (i < NowQuest.Reward.Count)
            {
                Instantiate(NowQuest.Reward[i], QLQ.Q_Reword[i].transform.GetChild(0));
                QLQ.Q_Reword[i].transform.GetChild(1).gameObject.SetActive(false); // hidden_text
            }
            else
            {
                QLQ.Q_Reword[i].SetActive(false);
            }
        }
    }

    public void Conect_Proceeding_Quest()
    {
        //����Ʈ�� ������ ������ ����Ʈ �����쿡 ����
        NowQuest = transform.GetChild(0).GetComponent<Quest_Data>();
        Proceeding_Quest.Update_ProceedingQuest(NowQuest, true);
    }
    

    public void Conect_SubWindow(bool isQuesting)
    {
        Quest_SubWindow.Update_Window(NowQuest, true, isQuesting); // Ʈ�縦 ���߿� �ٲ���
    }

    public void Give_Quest_To_Request()
    {
        ++Quest_Num;
        Quest_Request.Input_Quest_Data(Quest_Prefabs[Quest_Num]);
    }

    public void Quest_Complete()
    {
        Proceeding_Quest.Quest_Complete();
        Quest_SubWindow.Quest_Complete();
        Quest_List.Quest_Complete();
    }
}
