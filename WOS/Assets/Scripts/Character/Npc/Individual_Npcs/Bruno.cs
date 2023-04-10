using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bruno : Npc
{
    [Header("-----Bruno-----")]
    public GameObject Meshs_OutLine;
    public GameObject Store_Window;
    public GameObject Strengthen_Window;

    public override void Outline_SetActive(bool b)
    {
        Meshs_OutLine.SetActive(b);
    }

    public override void Button0and1_ofChild()
    {
        Button0_Set();
        Button1_Set();
    }

    void Button0_Set()
    {
        Transform myButton = NpcTalk_Window.Buttons[0].transform;
        // ��ư �̸�
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "��ȭ";
        //Lock Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(true);
        //��Ŭ�� ����
        myButton.GetComponent<Button>().onClick.AddListener(Enhancement_Button);
        myButton.GetComponent<Button>().onClick.AddListener(Play_ClickSound);
        //Lock ��Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(false);
        //��ư Ȱ��ȭ
        myButton.gameObject.SetActive(true);
    }

    void Button1_Set()
    {
        Transform myButton = NpcTalk_Window.Buttons[1].transform;
        // ��ư �̸�
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "����";
        //Lock Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(true);
        //��Ŭ�� ����
        myButton.GetComponent<Button>().onClick.AddListener(Store_Button);
        myButton.GetComponent<Button>().onClick.AddListener(Play_ClickSound);
        //Lock ��Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(false);
        //��ư Ȱ��ȭ
        myButton.gameObject.SetActive(true);
    }

    void Enhancement_Button()
    {
        //���������� ����
        Store_Window.SetActive(false);
        //��ȭ������ Ű�� -> ��ġ����(����)
        Strengthen_Window.SetActive(true);
        Strengthen_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, 130);
        //�κ������� Ű�� -> ��ġ����(������)
        GameObject Inventory_Window = Dont_Destroy_Data.Inst.Inventory_Window.gameObject;
        Inventory_Window.SetActive(true);
        Inventory_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 130);
    }

    void Store_Button()
    {
        //��ȭ������ ����
        Strengthen_Window.SetActive(false);
        //���������� Ű�� -> ��ġ����(����)
        Store_Window.SetActive(true);
        Store_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, 130);
        //�κ������� Ű�� -> ��ġ����(������)
        GameObject Inventory_Window = Dont_Destroy_Data.Inst.Inventory_Window.gameObject;
        Inventory_Window.SetActive(true);
        Inventory_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 130);
    }

    public override void Button2_OnClick_ofChild()
    {
        Store_Window.SetActive(false);
        Dont_Destroy_Data.Inst.Inventory_Window.gameObject.SetActive(false);
    }

    public override void Child_Reaction()
    {
        //����
        GetComponent<AudioSource>().Play();
    }
}
