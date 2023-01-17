using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using TMPro;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;
    Proceeding_Quest nowPQ;

    private void Start()
    {
        Child_Start_Setting();
    }

    public override void Outline_Active() // �ƿ����� ����
    {
        Body_Outline.SetActive(true);
    }

    public override void Outline_Unactive() // �ƿ����� ����
    {
        Body_Outline.SetActive(false);
    }

    enum Q_STATE
    {
        Questing, Complete, None 
    }
    
    Q_STATE Q_state = Q_STATE.None;

    public override void Button_0and1_Set(Proceeding_Quest PQ) // ����Ʈ�� ���¸� ����
    {
        nowPQ = PQ;
        if (nowPQ.isQuesting_Obj[1].activeSelf == true)
        {
            if(nowPQ.Progress.text == "������")
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

    public void Button0_Set()
    {
        Transform myButton = C_Data.NpcTalk_Window.Buttons[0].transform;
        // ��ư �̸�
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "�Ϸ�� ����Ʈ ����";
        //Lock Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(true);
        //��Ŭ�� ����
        myButton.GetComponent<Button>().onClick.AddListener(QuestComplete_Button);

        if(Q_state== Q_STATE.Complete) 
        {
            myButton.GetChild(1).gameObject.SetActive(false);
            myButton.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ �Ϸ� ����";
        }

        //��ư Ȱ��ȭ
        myButton.gameObject.SetActive(true);
    }

    public void Button1_Set()
    {
        Transform myButton = C_Data.NpcTalk_Window.Buttons[1].transform;
        // ��ư �̸�
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ ��û";
        //Lock Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(true);
        //��Ŭ�� ����
        myButton.GetComponent<Button>().onClick.AddListener(QuestRequest_Btton);

        if(Q_state == Q_STATE.None) // ���� ����Ʈ�� ���ٸ� = ���ο� ����Ʈ�� ������ �Դٸ�
        {
            //Lock ��Ȱ��ȭ
            myButton.GetChild(1).gameObject.SetActive(false);
        }

        //��ư Ȱ��ȭ
        myButton.gameObject.SetActive(true);
    }

    void QuestComplete_Button()
    {
        //�̺�Ʈ���� ����Ʈ ��������
        Quest_Complete QC = C_Data.NpcTalk_Window.Event_Window.Events[0].GetComponent<Quest_Complete>();

        QC.Q_Name.text = nowPQ.Name.text;
        for(int i = 0; i < 3; i++) // ���󰹼��� �°� ���󽽷� Ȱ��ȭ
        {
            if(nowPQ.Reward_Slots[i].activeSelf == true)
            {
                Instantiate(nowPQ.Reward_Slots[i].transform.GetChild(0).GetChild(0).gameObject, QC.Q_Reword[i].transform.GetChild(0));
                QC.Q_Reword[i].SetActive(true);
            }
            else
            {
                QC.Q_Reword[i].SetActive(false);
            }
        }

        //�̺�Ʈ Ȱ��ȭ
        QC.gameObject.SetActive(true);
        QC.transform.GetComponent<Animator>().SetBool("Open", true);

        //Npc������ ��Ȱ��ȭ
        I_Data.Npc_Icon.SetActive(false);

        // 0�� ��ư ��Ȱ��ȭ
        C_Data.NpcTalk_Window.Buttons[0].GetComponent<Button>().onClick.RemoveListener(QuestComplete_Button);
        C_Data.NpcTalk_Window.Buttons[0].GetComponent<Image>().color = Color.gray;
    }

    void QuestRequest_Btton()
    {
        C_Data.NpcTalk_Window.Event_Window.Events[1].SetActive(true); // ������Ʈ ������ ����
    }
}
