using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_List : MonoBehaviour
{
    public Quest_Data[] Quest_Datas; // ����Ʈ��
    public QL_Quest[] QL_Quests;
    public Manager_Quest Manager_Quest;

    Quest_Data QD;

    private void Start()
    {
        

        
    }

    //����Ʈ �Ϸ�-> ���� ����Ʈ ���ø�Ʈ,���� ����Ʈ ��� ����
    public void Quest_Complete()
    {
        //int num = Manager_Quest.NowQuest.Quest_Number;

        //�Ϸ�� ����Ʈ "Complete" �������
        //QL_Quests[num].Complete_Quest();
        //���� ����Ʈ �������
        //QL_Quests[num + 1].UnLock_Quest();
    }
}
