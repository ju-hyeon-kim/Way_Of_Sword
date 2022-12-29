using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inven_Slot : Item_Slot
{
    public InvenSlot_Type myType = default; // �ν����Ϳ��� ������

    public override void DropEvent(PointerEventData eventData)
    {
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 0��° �ڽ����� ����
        eventData.pointerDrag.transform.SetAsFirstSibling(); 
    }

    public override bool TypeDetect(PointerEventData eventData)
    {
        int typeNum = 0;
        switch(myType)
        {
            case InvenSlot_Type.Equipment:
                typeNum = 0;
                break;
            case InvenSlot_Type.Expendables:
                typeNum = 1;
                break;
            case InvenSlot_Type.Ingredient:
                typeNum = 2;
                break;
        }

        //�������� Ÿ���� ����� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().Item_Data.ItemType == (Item.Type)typeNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
