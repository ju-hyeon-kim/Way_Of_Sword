using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenEquipment_Slot : Inven_Slot
{
    public override bool TypeDetect(PointerEventData eventData)
    {
        //아이템의 타입이 장비라면 true를 반환, 아니면 false를 반환
        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == Item.Type.Equipment)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
