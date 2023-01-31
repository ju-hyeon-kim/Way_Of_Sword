using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Equipment_2D : Item_2D
{
    public override void GiveData_DW() // ������ ���� â�� ������ ���� �ǳ��ֱ�
    {
        Equipment_Data edata = myData.GetComponent<Equipment_Data>(); // ��ũ���ͺ� ������Ʈ�� ������Ʈ�� ���������ʱ⿡  �ش� ���� ���Ұ�

        //�̹���
        ItemData_Window.Inst.Public_Set.Image.sprite = GetComponent<Image>().sprite;
        //�̸�
        ItemData_Window.Inst.Public_Set.Name.text = edata.Name;

        //��ȭ
        if (edata.Strengthen > 0)
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = $"+{edata.Strengthen}";
        }
        else
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = "";
        }
        //����
        ItemData_Window.Inst.Public_Set.Price.text = $"�Ǹ� ����: {edata.Price} G";


        //Ÿ��
        string t = "";
        switch (edata.EquipmentType)
        {
            case EquipmentType.Weapon:
                t = "��� - ����";
                break;
            case EquipmentType.Necklace:
                t = "��� - �����";
                break;
            case EquipmentType.Bracelet:
                t = "��� - ����";
                break;
            case EquipmentType.Ring:
                t = "��� - ����";
                break;
            case EquipmentType.Helmet:
                t = "��� - ����";
                break;
            case EquipmentType.Top:
                t = "��� - ����";
                break;
            case EquipmentType.Pants:
                t = "��� - ����";
                break;
            case EquipmentType.Boots:
                t = "��� - �Ź�";
                break;
        }
        ItemData_Window.Inst.Public_Set.Type.text = t;
        //AP
        ItemData_Window.Inst.Equipment_Set.AP.text = $"���ݷ�: {edata.AP}";
        //����
        ItemData_Window.Inst.Equipment_Set.Explanation_Text.text = edata.Explanation;
        //������ �����
        for(int i = 0; i<4; i++)
        {
            if(edata.Equipped_Obes[i] != null)
            {
                //ItemData_Window.Inst.Equipment_Set.Equipped_Obes.Obe_Icons[i].sprite = edata.Equipped_Obes[i].Image;
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
