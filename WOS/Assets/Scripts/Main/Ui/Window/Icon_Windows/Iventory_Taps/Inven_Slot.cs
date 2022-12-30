using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inven_Slot : Item_Slot
{
    public Item.Type SlotType = default; // �ν����Ϳ��� ������

    public override void DropEvent(PointerEventData eventData)
    {
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 0��° �ڽ����� ����
        eventData.pointerDrag.transform.SetAsFirstSibling(); 
    }

    public override bool TypeDetect(PointerEventData eventData)
    {
        //�������� Ÿ���� ����� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().Item_Data.ItemType == SlotType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
