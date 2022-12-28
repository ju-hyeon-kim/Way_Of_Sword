using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenExpendables_Slot : Inven_Slot
{
    public override bool TypeDetect(PointerEventData eventData)
    {
        //�������� Ÿ���� �Ҹ�ǰ�̶�� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == Item.Type.Expendables)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
