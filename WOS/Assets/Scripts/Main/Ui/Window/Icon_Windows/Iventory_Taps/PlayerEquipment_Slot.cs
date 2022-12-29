using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerEquipment_Slot : Item_Slot
{
    public PESlot_Type myType = default; // 인스펙터에서 정해줌

    public override void DropEvent(PointerEventData eventData)
    {
        // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
        eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // 오브제는 슬롯의 2번째 자식으로 설정
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

        //아이템의 타입이 장비라면 true를 반환, 아니면 false를 반환
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
