using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using TMPro;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;

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
        if(PQ.Progress.text == "�Ϸ�")
        {
            //0�� ��ư -> ����Ʈ �Ϸ�
            NpcTalk_Window.Inst.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ �Ϸ� ����";
            NpcTalk_Window.Inst.Buttons[0].GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        }
        
        //��ư Ȱ��ȭ
        NpcTalk_Window.Inst.Buttons[0].SetActive(true);
    }
    public override void Button1_Set(Proceeding_Quest PQ)
    {
        //1�� ��ư
        NpcTalk_Window.Inst.Buttons[1].GetComponent<Image>().color = Color.gray;
        NpcTalk_Window.Inst.Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ ��û";
        //Lock Ȱ��ȭ -> ���߿� ���� Ǯ���� �ñⰡ �������� �Ʒ� �ڵ带 if������ ���� �����ֱ�
        NpcTalk_Window.Inst.Buttons[1].transform.GetChild(1).gameObject.SetActive(true);
        //��ư Ȱ��ȭ
        NpcTalk_Window.Inst.Buttons[1].SetActive(true);
    }

    void QuestComplete_Button()
    {
        //�̺�Ʈ
        NpcTalk_Window.Inst.Events[0].SetActive(true);
        NpcTalk_Window.Inst.Events[0].GetComponent<Animator>().SetBool("Open", true);

        //Npc������ ��Ȱ��ȭ
        I_Data.Npc_Icon.SetActive(false);

        // 0�� ��ư ��Ȱ��ȭ
        NpcTalk_Window.Inst.Buttons[0].GetComponent<Button>().onClick.RemoveListener(QuestComplete_Button);
        NpcTalk_Window.Inst.Buttons[0].GetComponent<Image>().color = Color.gray;
    }
}
