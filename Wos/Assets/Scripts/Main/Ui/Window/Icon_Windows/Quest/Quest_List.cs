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
        //0��° ����Ʈ ����
        Instantiate(Quest_Datas[0], Manager_Quest.transform);

        //'�������� ����Ʈ' �ǰ� ����
        Manager_Quest.Conect_Proceeding_Quest();

        //Po_Qeusts[0] Ȱ��ȭ
        Manager_Quest.Conect_Qeust_List(0);

        //������ ����
        Manager_Quest.OnStart_Questing();
    }

    //����Ʈ �Ϸ�-> ���� ����Ʈ ���ø�Ʈ,���� ����Ʈ ��� ����
    public void Quest_Complete()
    {
        int num = Manager_Quest.NowQuest.Quest_Number;

        //�Ϸ�� ����Ʈ "Complete" �������
        QL_Quests[num].Complete_Quest();
        //���� ����Ʈ �������
        QL_Quests[num + 1].UnLock_Quest();
    }
}
