using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerEquipment_Slot : Item_Slot
{
    // �ν����Ϳ��� ������
    public Item.Type ItmeType_slot = default; 
    public Item.EquipmentType EquipmentType_slot = default;


    public override void DropEvent(PointerEventData eventData)
    {
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 2��° �ڽ����� ����
        eventData.pointerDrag.transform.SetSiblingIndex(1);
    }

    public override bool TypeDetect(PointerEventData eventData)
    {
        Item_Icon myItem = eventData.pointerDrag.transform.GetComponent<Item_Icon>();
        //�������� Ÿ���� ����� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (myItem.Item_Data.ItemType == ItmeType_slot && myItem.Item_Data.EquipmentType == EquipmentType_slot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
