using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;
using TMPro;
using UnityEngine.UI;

public class Lucia : Npc
{
    public GameObject Body_Outline;
    NpcTalk_Window NW;

    private void Start()
    {
        Child_Start_Setting();
        NW = NpcTalk_Window.Inst;
    }

    public override void Outline_Active() // �ƿ����� ����
    {
        Body_Outline.SetActive(true);
    }

    public override void Outline_Unactive() // �ƿ����� ����
    {
        Body_Outline.SetActive(false);
    }

    public override void Connect_Window_Individual()
    {
        // ��ư Ȱ��ȭ 
        
        //0�� ��ư
        NW.Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ �Ϸ� 1��";
        NW.Buttons[0].GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        //1�� ��ư
        NW.Buttons[1].GetComponent<Image>().color = Color.gray;
        NW.Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ ��û";
        //Lock Ȱ��ȭ -> ���߿� ���� Ǯ���� �ñⰡ �������� �Ʒ� �ڵ带 if������ ���� �����ֱ�
        NW.Buttons[1].transform.GetChild(1).gameObject.SetActive(true);
    }

    void QuestComplete_Button()
    {
        //�̺�Ʈ
        NW.Events[0].SetActive(true);
        NW.Events[0].GetComponent<Animator>().SetBool("Open", true);

        //���� ���� -> ���߿� ����

        //Npc������ ��Ȱ��ȭ
        I_Data.Npc_Icon.SetActive(false);
    }
}
