using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwordObe_Slot : Item_Slot
{
    public Item_Types.ItemType SlotType = default; // 인스펙터에서 정해줌
    public Transform mySkill_Icon;
    public Transform myWeapon_Slot;
    public Skill_Set mySkill_Set;
    public int mySlotNum;

    public override bool TypeDetect(PointerEventData eventData)
    {
        //아이템의 타입이 오브라면 true를 반환, 아니면 false를 반환

        if (eventData.pointerDrag.transform.GetComponent<Item_2D>().myType == SlotType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void DropEvent(PointerEventData eventData) //오브를 받았을 때
    {
        Transform ED = eventData.pointerDrag.transform;

        // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
        ED.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // 오브제는 슬롯의 0번째 자식으로 설정
        ED.SetAsFirstSibling();
        // 스킬셋에 스킬 데이터 건네주기
        ED.GetComponent<Obe_2D>().Give_Skill_Data();
        // 무기의 '장착된 오브들(Equipped_Obes)'과 연동
        //myWeapon_Slot.GetChild(1).GetComponent<Equipment_2D>().Equipment_Data.Equipped_Obes[mySlotNum] = ED.GetComponent<Obe_2D>().Obe_Data;

        // 현재 소드아이콘 윈도우의 상황에 맞게 '장착된 오브들(Equipped_Obes)' 세팅 = 다른 소드오브슬롯에서 오브를 받았을 때
        // + 스킬셋도 세팅
        for(int i = 0; i < 4; i++)
        {
            if (transform.parent.GetChild(i).childCount == 0) //소드오브슬롯의 자식이 없다면
            {
                myWeapon_Slot.GetChild(1).GetComponent<Equipment_2D>().Equipment_Data.Equipped_Obes[i] = null;
                mySkill_Set.Skill_Icons[i].SetActive(false);
            }
        }
    }
}
