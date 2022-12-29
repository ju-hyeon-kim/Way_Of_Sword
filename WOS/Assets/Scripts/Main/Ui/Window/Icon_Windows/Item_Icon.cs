using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_Icon : Item_2D
{
    public Item_Data Item_Data;

    public override void GiveData() // ������ ���� â�� ������ �ǳ��ֱ�
    {
        //�̹���
        ItemData_Window.Inst.Image.sprite = Item_Data.Image;
        //�̸�
        ItemData_Window.Inst.Name.text = Item_Data.Name;
        //Ÿ��
        ItemData_Window.Inst.Type.text = Item_Data.Type;
        //AP
        ItemData_Window.Inst.AP.text = $"���ݷ�: {Item_Data.AP}";
        //����
        ItemData_Window.Inst.Price.text = $"�Ǹ� ����: {Item_Data.Price} G";
        //����
        ItemData_Window.Inst.Explanation_Text.text = Item_Data.Explanation_Text;
    }
}
