using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inven_Slot : Item_Slot
{
    public Item.Type SlotType = default; // 인스펙터에서 정해줌

    public override bool TypeDetect(PointerEventData eventData)
    {
        //아이템의 타입이 슬롯 타입과 같다면 true를 반환, 아니면 false를 반환
        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == SlotType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void DropEvent(PointerEventData eventData)
    {
        Transform myItem = eventData.pointerDrag.transform;
        // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
        myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // 오브제는 슬롯의 0번째 자식으로 설정
        myItem.transform.SetAsFirstSibling();
        // 오브 슬롯이라면
        if(SlotType == Item.Type.Obe)
        {
            myItem.GetComponent<Obe_Icon>().SkillSet_Conection();
        }
    }
}
