using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenIngredient_Slot : Inven_Slot
{
    public override bool TypeDetect(PointerEventData eventData)
    {
        //�������� Ÿ���� ����� true�� ��ȯ, �ƴϸ� false�� ��ȯ
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
