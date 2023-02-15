using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwordObe_Slot : Item_Slot
{
    public ItemType SlotType = default; // 인스펙터에서 정해줌
    public Weapon_Slot Weapon_Slot;
    public Skill_Slot mySkill_Slot;

    public override bool TypeDetect(PointerEventData eventData)
    {
        //아이템의 타입이 오브라면 true를 반환, 아니면 false를 반환

        if (eventData.pointerDrag.transform.GetComponent<Item_2D>().myData.ItemType == SlotType)
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
        Obe_2D Obe2D = eventData.pointerDrag.GetComponent<Obe_2D>();

        // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
        Obe2D.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        // 오브제는 슬롯의 0번째 자식으로 설정
        Obe2D.transform.SetAsFirstSibling();

        // 스킬슬롯에 스킬 전달
        Obe_Data ObeData = Obe2D.myData as Obe_Data;
        GameObject obj = Instantiate(ObeData.Skill_2D.gameObject, mySkill_Slot.transform);

        // 무기의 '장착된 오브들(Equipped_Obes)'과 연동
        for(int i = 0; i < Weapon_Slot.SwordObe_Slots.Length; i++)
        {
            if (Weapon_Slot.SwordObe_Slots[i] == this)
            {
                Weapon_Data WeaponData = Weapon_Slot.myWeapon.myData as Weapon_Data;
                WeaponData.Equipped_Obes[i] = ObeData;
            }
        }
    }
}
