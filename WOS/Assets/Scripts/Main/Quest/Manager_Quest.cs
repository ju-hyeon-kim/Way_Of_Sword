using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Quest : MonoBehaviour
{
    public Proceeding_Quest Proceeding_Quest;
    public Quest_SubWindow Quest_SubWindow;
    public Quest_List Quest_List;
    public GameObject[] Quest_Prefabs;
    public Quest_Request Quest_Request;
    public int Quest_Num = 0;
    public Quest_Guide Quest_Guide;
    public Transform[] Guide_Tartgets = new Transform[10]; // Guide_Tartgets[num] = Quest_num�� Ÿ��
    public Quest_Data NowQuest;

    #region �̱��� ���� + Awake()
    private static Manager_Quest Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
    }

    public static Manager_Quest Inst
    {
        get
        {
            if (Instence == null) // �ٸ� ������Ʈ�� Awake()���� Inst�� ȣ���� ���
            {
                return null;
            }
            return Instence;
        }
    }
    #endregion

    private void Start()
    {
        Change_Quest();
    }

    public void Change_Quest()
    {
        if (transform.childCount > 0) // �Ŵ������� �ڽ��� �ִٸ� = ������ ����Ʈ�� �����Ǿ��ִٸ�
        {
            Destroy(transform.GetChild(0).gameObject); // �ش� ����Ʈ �ı�
        }
        GameObject obj = Instantiate(Quest_Prefabs[Quest_Num], transform);
        NowQuest = obj.GetComponent<Quest_Data>();

        Quest_List.Change_Quest(NowQuest);
        Proceeding_Quest.Change_Quest(NowQuest);
        Quest_SubWindow.Change_Quest(NowQuest);

        GetComponentInChildren<Quest_Data>().Start_Questing();

        Quest_Guide.gameObject.SetActive(true);
        Quest_Guide.StartGuiding();
    }

    public void Complete_Quest()
    {
        Proceeding_Quest.Complete_Quest();
        Quest_SubWindow.Complete_Quest();

        Quest_Guide.StopGuiding();
        Quest_Guide.gameObject.SetActive(false);
    }

    public void None_Qeust()
    {
        ++Quest_Num;

        Proceeding_Quest.None_Quest();
        Quest_SubWindow.None_Quest();
        Quest_List.None_Quest(Quest_Num);

        //����Ʈ ��û���� ���� ����Ʈ ���� ����
        Quest_Request.Input_Quest_Data(Quest_Prefabs[Quest_Num].GetComponent<Quest_Data>());
    }
}
