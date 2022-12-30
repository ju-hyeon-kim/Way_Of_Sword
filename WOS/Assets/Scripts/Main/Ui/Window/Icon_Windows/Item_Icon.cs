using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_Icon : Item_2D
{
    public Item_Data Item_Data;

    public override void GiveData() // ������ ���� â�� ������ ���� �ǳ��ֱ�
    {
        //�̹���
        ItemData_Window.Inst.Image.sprite = Item_Data.Image;
        //�̸�
        ItemData_Window.Inst.Name.text = Item_Data.Name;
        //Ÿ��
        string t ="";
        switch(Item_Data.ItemType)
        {
            case Item.Type.Equipment:
                switch(Item_Data.EquipmentType)
                {
                    case Item.EquipmentType.Weapon:
                        t = "��� - ����";
                        break;
                    case Item.EquipmentType.Necklace:
                        t = "��� - �����";
                        break;
                    case Item.EquipmentType.Bracelet:
                        t = "��� - ����";
                        break;
                    case Item.EquipmentType.Ring:
                        t = "��� - ����";
                        break;
                    case Item.EquipmentType.Helmet:
                        t = "��� - ����";
                        break;
                    case Item.EquipmentType.Top:
                        t = "��� - ����";
                        break;
                    case Item.EquipmentType.Pants:
                        t = "��� - ����";
                        break;
                    case Item.EquipmentType.Boots:
                        t = "��� - �Ź�";
                        break;
                }
                break;
            case Item.Type.Obe:
                t = "����";
                break;
            case Item.Type.Expendables:
                t = "�Ҹ�ǰ";
                break;
            case Item.Type.Ingredient:
                t = "���";
                break;
        }
        ItemData_Window.Inst.Type.text = t;
        //AP
        ItemData_Window.Inst.AP.text = $"���ݷ�: {Item_Data.AP}";
        //����
        ItemData_Window.Inst.Price.text = $"�Ǹ� ����: {Item_Data.Price} G";
        //����
        ItemData_Window.Inst.Explanation_Text.text = Item_Data.Explanation_Text;
    }
}
