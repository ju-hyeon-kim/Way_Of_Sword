using UnityEngine;

public class Manager_Quest : MonoBehaviour
{
    public Proceeding_Quest Proceeding_Quest;
    public Quest_SubWindow Quest_SubWindow;
    public Quest_List Quest_List;
    public Quest_Data[] Quest_Datas;
    public Quest_Request Quest_Request;
    public int Quest_Num = 0;
    public Quest_Guide Quest_Guide;
    public Transform[] Guide_Targets; // Guide_Tartgets[num] = Quest_num�� Ÿ��
    public Quest_Data NowQuest;

    public void Start_Setting(Transform PlaceManager)
    {
        Guide_Targets = PlaceManager.GetComponent<Manager_Place>().Guide_Tartgets;
        Change_Quest();
    }

    public void Change_Quest()
    {
        if (transform.childCount > 0) // �Ŵ������� �ڽ��� �ִٸ� = ������ ����Ʈ�� �����Ǿ��ִٸ�
        {
            Destroy(transform.GetChild(0).gameObject); // �ش� ����Ʈ �ı�
        }
        GameObject obj = Instantiate(Quest_Datas[Quest_Num].gameObject, transform);
        NowQuest = obj.GetComponent<Quest_Data>();

        Quest_List.Change_Quest(NowQuest);
        Proceeding_Quest.Change_Quest(NowQuest);
        Quest_SubWindow.Change_Quest(NowQuest);

        NowQuest.GetComponent<Quest_Data>().Quest_isStart = true;
        NowQuest.GetComponent<Quest_Data>().Start_Questing();

        Quest_Guide.Change_Quest();
    }

    public void Complete_Quest()
    {
        Proceeding_Quest.Complete_Quest();
        Quest_SubWindow.Complete_Quest();
        Quest_Guide.Complete_Quest();
    }

    public void None_Qeust()
    {
        ++Quest_Num;

        Proceeding_Quest.None_Quest();
        Quest_SubWindow.None_Quest();
        Quest_List.None_Quest(Quest_Num);

        //����Ʈ ��û���� ���� ����Ʈ ���� ����
        Quest_Request.Input_QuestData(Quest_Datas[Quest_Num].GetComponent<Quest_Data>());
    }

    public void Add_KillCount(int count)
    {
        Proceeding_Quest.Add_KillCount(count);
        Quest_SubWindow.Add_KillCount(count);
    }

    public void SceneChange() //�ε������� �Ѿ �� Missing ���� ���� 
    {
        for (int i = 0; i < Guide_Targets.Length; i++)
        {
            Guide_Targets[i] = this.transform;
        }
    }
    
    public void LoadQuest(string questname)
    {
        for(int i = 0; i < Quest_Datas.Length; i++)
        {
            if(Quest_Datas[i].Name == questname)
            {
                Quest_Num = i;
            }
        }
    }
}
