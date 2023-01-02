using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwordObe_Slot : Item_Slot
{
    public Item.Type SlotType = default; // 인스펙터에서 정해줌
    public Transform mySkill_Slot;
    public Transform myWeapon_Slot;
    public int mySlotNum;

    public override bool TypeDetect(PointerEventData eventData)
    {
        //아이템의 타입이 오브라면 true를 반환, 아니면 false를 반환

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
        Transform ED = eventData.pointerDrag.transform;
        // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
        ED.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // 오브제는 슬롯의 0번째 자식으로 설정
        ED.SetAsFirstSibling();

        // 무기의 Equipment_Data.Equipped_Obes 와 연동


        //인벤토리로부터 오브를 받았을 때
        // 스킬셋(인터페이스)과 연동
        ED.GetComponent<Obe_Icon>().SkillSet_Conection();
        // 무기와 연동
        myWeapon_Slot.GetChild(1).GetComponent<Equipment_Icon>().Equipment_Data.Equipped_Obes[mySlotNum] = ED.GetComponent<Obe_Icon>().Obe_Data;
    }
}
