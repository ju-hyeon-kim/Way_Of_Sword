using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using TMPro;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;
    Proceeding_Quest PQ_Data;
    

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

    public override void Button0_Set(Proceeding_Quest PQ)
    {
        PQ_Data = PQ; // -> QuestComplete_Button()�Լ��� ����� �� �ְ� ��������� ���� �޾Ƶ�

        if (PQ.Progress.text == "�Ϸ�") //����Ʈ�� �Ϸ� ���¶��
        {
            //��ư�� ��Ŭ�� ����
            C_Data.NpcTalk_Window.Buttons[0].GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        }
        else // ������ ���¶��
        {
            C_Data.NpcTalk_Window.Buttons[0].GetComponent<Image>().color = Color.gray; // ȸ������ ���̰�
        }

        //��ư Ȱ��ȭ
        C_Data.NpcTalk_Window.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ �Ϸ� ����";
        C_Data.NpcTalk_Window.Buttons[0].SetActive(true);
    }
    public override void Button1_Set(Proceeding_Quest PQ)
    {
        //1�� ��ư
        C_Data.NpcTalk_Window.Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ ��û";
        //Lock Ȱ��ȭ -> ���߿� ���� Ǯ���� �ñⰡ �������� �Ʒ� �ڵ带 if������ ���� �����ֱ�
        C_Data.NpcTalk_Window.Buttons[1].transform.GetChild(1).gameObject.SetActive(true);
        //��Ŭ�� ����
        C_Data.NpcTalk_Window.Buttons[1].GetComponent<Button>().onClick.AddListener(QuestRequest_Btton);
        //��ư Ȱ��ȭ
        C_Data.NpcTalk_Window.Buttons[1].SetActive(true);
    }

    void QuestComplete_Button()
    {
        //�̺�Ʈ���� ����Ʈ ��������
        Quest_Complete QC = C_Data.NpcTalk_Window.Events[0].GetComponent<Quest_Complete>();
        QC.Q_Name.text = PQ_Data.Name.text;
        for(int i = 0; i < 3; i++) // ���󰹼��� �°� ���󽽷� Ȱ��ȭ
        {
            if(PQ_Data.Reward_Slots[i].activeSelf == true)
            {
                Instantiate(PQ_Data.Reward_Slots[i].transform.GetChild(0).GetChild(0).gameObject, QC.Q_Reword[i].transform.GetChild(0));
                QC.Q_Reword[i].SetActive(true);
            }
            else
            {
                QC.Q_Reword[i].SetActive(false);
            }
        }

        //�̺�Ʈ Ȱ��ȭ
        C_Data.NpcTalk_Window.Events[0].SetActive(true);
        C_Data.NpcTalk_Window.Events[0].GetComponent<Animator>().SetBool("Open", true);

        //Npc������ ��Ȱ��ȭ
        I_Data.Npc_Icon.SetActive(false);

        // 0�� ��ư ��Ȱ��ȭ
        C_Data.NpcTalk_Window.Buttons[0].GetComponent<Button>().onClick.RemoveListener(QuestComplete_Button);
        C_Data.NpcTalk_Window.Buttons[0].GetComponent<Image>().color = Color.gray;
    }

    void QuestRequest_Btton()
    {
        C_Data.NpcTalk_Window.Events[1].SetActive(true); // ������Ʈ ������ ����
    }
}
