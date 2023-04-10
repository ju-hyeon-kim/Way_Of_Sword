using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;
    Proceeding_Quest nowPQ;

    private void Start()
    {
        Child_Start_Setting();
    }

    public override void Outline_SetActive(bool b) // �ƿ����� ����
    {
        Body_Outline.SetActive(b);
    }

    enum Q_STATE
    {
        Questing, Complete, None
    }

    Q_STATE Q_state = Q_STATE.None;

    public override void Button0and1_ofChild() 
    {
        // ����Ʈ�� ���¸� ����
        nowPQ = Dont_Destroy_Data.Inst.Manager_Quest.Proceeding_Quest;
        if (nowPQ.Q_Exist_Settings[1].activeSelf == true)
        {
            if (nowPQ.Progress.text == "������")
            {
                //���� ����Ʈ�� ���� ������ ������ �� -> ���� ����Ʈ ������
                Q_state = Q_STATE.Questing;
            }
            else
            {
                //���� ����Ʈ�� ���� ���� ������ �� -> �Ϸ� ���� �Ϸ� ���� ��
                Q_state = Q_STATE.Complete;
            }
        }
        else
        {
            //���� ����Ʈ�� ���� �� -> ����Ʈ�� ��û �Ϸ� ���� ��
            Q_state = Q_STATE.None;
        }
        Button0_Set();
        Button1_Set();
    }

    void Button0_Set()
    {
        Transform myButton = NpcTalk_Window.Buttons[0].transform;
        // ��ư �̸�
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "�Ϸ�� ����Ʈ ����";
        //Lock Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(true);
        //��Ŭ�� ����
        myButton.GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        myButton.GetComponent<Button>().onClick.AddListener(Play_ClickSound);

        if (Q_state == Q_STATE.Complete)
        {
            myButton.GetChild(1).gameObject.SetActive(false);
            myButton.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ �Ϸ� ����";
        }

        //��ư Ȱ��ȭ
        myButton.gameObject.SetActive(true);
    }

    void Button1_Set()
    {
        Transform myButton = NpcTalk_Window.Buttons[1].transform;
        // ��ư �̸�
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ ��û";
        //Lock Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(true);
        //��Ŭ�� ����
        myButton.GetComponent<Button>().onClick.AddListener(QuestRequest_Btton);
        myButton.GetComponent<Button>().onClick.AddListener(Play_ClickSound);

        if (Q_state == Q_STATE.None) // ���� ����Ʈ�� ���ٸ� = ���ο� ����Ʈ�� ������ �Դٸ�
        {
            //Lock ��Ȱ��ȭ
            myButton.GetChild(1).gameObject.SetActive(false);
        }

        //��ư Ȱ��ȭ
        myButton.gameObject.SetActive(true);
    }

    void QuestComplete_Button()
    {
        //Quest_Complete���� ����Ʈ ��������
        Quest_Complete QC = NpcTalk_Window.Event_Window.Events[0].GetComponent<Quest_Complete>();

        QC.Q_Name.text = nowPQ.Name.text;
        Quest_Data nowQD = Dont_Destroy_Data.Inst.Manager_Quest.NowQuest;
        int RewardCount = nowQD.Reward.Length;

        for (int i = 0; i < 3; i++)
        {
            if (i < RewardCount)
            {
                GameObject Obj = Instantiate(nowQD.Reward[i], QC.Q_Reword[i].transform) as GameObject;
                Obj.transform.SetAsFirstSibling();
                QC.Q_Reword[i].SetActive(true);
            }
            else
            {
                QC.Q_Reword[i].SetActive(false);
            }
        }
        //sfx
        //Manager_Sound.Inst.SfxSource.OnPlay(11);

        //�̺�Ʈ Ȱ��ȭ
        QC.gameObject.SetActive(true);
        QC.transform.GetComponent<Animator>().SetBool("Open", true);

        // 0�� ��ư Lock ����
        NpcTalk_Window.Lock_or_Unlock_Button(0, true);
        NpcTalk_Window.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "�Ϸ�� ����Ʈ ����";
    }

    void QuestRequest_Btton()
    {
        NpcTalk_Window.Event_Window.Events[1].SetActive(true); // ������Ʈ ������ ����
    }

    public override void Child_Reaction()
    {
        //����
        GetComponent<AudioSource>().Play();
    }
}