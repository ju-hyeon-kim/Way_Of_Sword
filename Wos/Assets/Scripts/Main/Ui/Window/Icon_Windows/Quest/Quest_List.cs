using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_List : MonoBehaviour
{
    public QL_Quest[] QL_Quests;
    public Manager_Quest Manager_Quest;

    public void Update_Data()
    {

    }

    public void Quest_Complete(Quest_Data nextQD)
    {
        // �Ϸ�� ����Ʈ -> �Ϸ� ���� ���
        QL_Quests[nextQD.Quest_Number - 1].Complete_Quest();

        // ���� ����Ʈ�� ����Ʈ ����
        QL_Quests[nextQD.Quest_Number].UnLock_Quest();
    }
}
