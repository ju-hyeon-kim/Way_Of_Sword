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
        if (myItem != null) // 슬롯이 비어있지 않다면
        {
            Armor_Data weaponData = (Armor_Data)myItem.myData;
            return weaponData.Dp;
        }
        else
        {
            return 0;
        }
    }

    public override void Change_Item(Item_2D beforeItem, Item_2D newItem) // 슬롯에 이미 아이템이있는데 다른아이템을 드랍받으려 한다면
    {
        //2D무기교체
        //beforeItem
        beforeItem.transform.SetParent(newItem.Before_Slot.transform);
        beforeItem.transform.SetAsFirstSibling();
        beforeItem.transform.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
        beforeItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // 사이즈 슬롯에 맞게 설정
        //newItem
        newItem.transform.SetParent(this.transform);
        newItem.transform.SetAsFirstSibling();
        newItem.transform.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
        newItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // 사이즈 슬롯에 맞게 설정
    }
}
