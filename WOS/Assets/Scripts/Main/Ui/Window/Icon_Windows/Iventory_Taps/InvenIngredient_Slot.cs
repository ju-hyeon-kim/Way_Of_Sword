using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenIngredient_Slot : Inven_Slot
{
    public override bool TypeDetect(PointerEventData eventData)
    {
        //아이템의 타입이 재료라면 true를 반환, 아니면 false를 반환
        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == Item.Type.Ingredient)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
