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

    public override void Outline_SetActive(bool b)
    {
        Meshs_OutLine.SetActive(b);
    }

    public override void Button_0and1_Set()
    {
        //Button0_Set(); -> 0��ư ��ȹ ����
        Button1_Set();
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
        //Lock ��Ȱ��ȭ
        myButton.GetChild(1).gameObject.SetActive(false);
        //��ư Ȱ��ȭ
        myButton.gameObject.SetActive(true);
    }

    void Store_Button()
    {
        //���������� Ű�� -> ��ġ����(����)
        Store_Window.SetActive(true);
        Store_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, 130);
        //�κ������� Ű�� -> ��ġ����(������)
        GameObject Inventory_Window = Dont_Destroy_Data.Inst.Inventory_Window.gameObject;
        Inventory_Window.SetActive(true);
        Inventory_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 130);
    }
}
