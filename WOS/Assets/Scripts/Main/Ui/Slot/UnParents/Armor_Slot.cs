using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Armor_Slot : EquipmentSlot_ofPlayerWindow
{
    [Header("-----Armor_Slot-----")]
    public ArmorType myArmorType;

    public override bool isSameType(Item_2D NewItem2D)
    {
        if (NewItem2D.TryGetComponent<Armor_2D>(out Armor_2D component))
        {
            Armor_Data ArmorData = component.myData as Armor_Data;
            if(ArmorData.ArmorType == myArmorType)
            {
                return true;
            }
        }
        return false;
    }

    public float Get_ArmorDp()
    {
        if (myItem != null) // ������ ������� �ʴٸ�
        {
            Armor_Data weaponData = (Armor_Data)myItem.myData;
            return weaponData.Dp;
        }
        else
        {
            return 0;
        }
    }

    public override void Change_Item(Item_2D beforeItem, Item_2D newItem) // ���Կ� �̹� ���������ִµ� �ٸ��������� ��������� �Ѵٸ�
    {
        //2D���ⱳü
        //beforeItem
        beforeItem.transform.SetParent(newItem.Before_Slot.transform);
        beforeItem.transform.SetAsFirstSibling();
        beforeItem.transform.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
        beforeItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // ������ ���Կ� �°� ����
        //newItem
        newItem.transform.SetParent(this.transform);
        newItem.transform.SetAsFirstSibling();
        newItem.transform.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
        newItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // ������ ���Կ� �°� ����
    }
}
