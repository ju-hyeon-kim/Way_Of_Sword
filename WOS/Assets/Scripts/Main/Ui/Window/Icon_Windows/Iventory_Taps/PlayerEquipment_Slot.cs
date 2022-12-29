using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerEquipment_Slot : Item_Slot
{
    public PESlot_Type myType = default; // �ν����Ϳ��� ������

    public override void DropEvent(PointerEventData eventData)
    {
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 2��° �ڽ����� ����
        eventData.pointerDrag.transform.SetSiblingIndex(1);
    }

    public override bool TypeDetect(PointerEventData eventData)
    {
        int typeNum = 0;
        switch (myType)
        {
            case PESlot_Type.Weapon:
                typeNum = 0;
                break;
            case PESlot_Type.Helmet:
                typeNum = 1;
                break;
        }

        //�������� Ÿ���� ����� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == (Item.Type)typeNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
