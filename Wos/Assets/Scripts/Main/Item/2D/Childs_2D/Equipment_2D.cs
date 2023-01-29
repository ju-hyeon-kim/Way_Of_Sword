using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Equipment_2D : Item_2D
{
    public Equipment_Data Equipment_Data;

    
    public override void GiveData_DW() // ������ ���� â�� ������ ���� �ǳ��ֱ�
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
        string t = "";
        switch (Equipment_Data.EquipmentType)
        {
            case Item_Types.EquipmentType.Weapon:
                t = "��� - ����";
                break;
            case Item_Types.EquipmentType.Necklace:
                t = "��� - �����";
                break;
            case Item_Types.EquipmentType.Bracelet:
                t = "��� - ����";
                break;
            case Item_Types.EquipmentType.Ring:
                t = "��� - ����";
                break;
            case Item_Types.EquipmentType.Helmet:
                t = "��� - ����";
                break;
            case Item_Types.EquipmentType.Top:
                t = "��� - ����";
                break;
            case Item_Types.EquipmentType.Pants:
                t = "��� - ����";
                break;
            case Item_Types.EquipmentType.Boots:
                t = "��� - �Ź�";
                break;
        }
        ItemData_Window.Inst.Public_Set.Type.text = t;
        //AP
        ItemData_Window.Inst.Equipment_Set.AP.text = $"���ݷ�: {Equipment_Data.AP}";
        //����
        ItemData_Window.Inst.Equipment_Set.Explanation_Text.text = Equipment_Data.Explanation_Text;
        //������ �����
        for(int i = 0; i<4; i++)
        {
            if(Equipment_Data.Equipped_Obes[i] != null)
            {
                ItemData_Window.Inst.Equipment_Set.Equipped_Obes.Obe_Icons[i].sprite = Equipment_Data.Equipped_Obes[i].Image;
                ItemData_Window.Inst.Equipment_Set.Equipped_Obes.Obe_Icons[i].gameObject.SetActive(true);
            }
            else
            {
                ItemData_Window.Inst.Equipment_Set.Equipped_Obes.Obe_Icons[i].gameObject.SetActive(false);
            }
        }
        

        //������ Ÿ�Կ� �´� ���� â�� Ȱ��ȭ
        for (int i = 0; i < 4; i++)
        {
            ItemData_Window.Inst.Type_Sets[i].SetActive(false);
            if (i == (int)myType)
            {
                ItemData_Window.Inst.Type_Sets[i].SetActive(true);
            }
        }
    }
}
