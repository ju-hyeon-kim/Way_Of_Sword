using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Equipment_Icon : Item_Icon
{
    public Equipment_Data Equipment_Data;

    string t = "";
    int typenum = 0;
    public override void GiveData() // ������ ���� â�� ������ ���� �ǳ��ֱ�
    {
        //�̹���
        ItemData_Window.Inst.Public_Set.Image.sprite = Equipment_Data.Image;
        //�̸�
        ItemData_Window.Inst.Public_Set.Name.text = Equipment_Data.Name;
        //��ȭ
        if (Equipment_Data.Strengthen > 0)
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = $"+{Equipment_Data.Strengthen}";
        }
        else
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = "";
        }
        //����
        ItemData_Window.Inst.Public_Set.Price.text = $"�Ǹ� ����: {Equipment_Data.Price} G";

        //Ÿ��
        switch (Equipment_Data.EquipmentType)
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
        ItemData_Window.Inst.Public_Set.Type.text = t;
        //AP
        ItemData_Window.Inst.Equipment_Set.AP.text = $"���ݷ�: {Equipment_Data.AP}";
        //����
        ItemData_Window.Inst.Equipment_Set.Explanation_Text.text = Equipment_Data.Explanation_Text;

        //������ Ÿ�Կ� �´� ���� â�� Ȱ��ȭ
        for (int i = 0; i < 4; i++)
        {
            ItemData_Window.Inst.Type_Sets[i].SetActive(false);
            if (i == typenum)
            {
                ItemData_Window.Inst.Type_Sets[i].SetActive(true);
            }
        }
    }

    public void Change_Parents() // ���� ����
    {
        if (Before_Parents.name == "Weapon")
        {
            Before_Parents.GetComponent<Weapon_Slot>().Equip_Control();
        }
    }
}
