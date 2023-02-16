using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObeSlot_inSword : Item_Slot
{
    public ItemType SlotType = default; // 인스펙터에서 정해줌
    public Weapon_Slot Weapon_Slot;
    public Skill_Slot mySkill_Slot;
    public int SlotNum;

    public void StartSetting() // SwordIcon_Window의 Start()에서 실행됨
    {
        if(this.transform.childCount > 0) // 자식이 있다면
        {
            // 스킬슬롯에 스킬 전달
            Obe_2D Obe2D = this.transform.GetChild(0).GetComponent<Obe_2D>();
            Obe_Data ObeData = Obe2D.myData as Obe_Data;

            GameObject obj = Instantiate(ObeData.Skill_2D.gameObject, mySkill_Slot.transform);
            obj.transform.SetAsFirstSibling();
            mySkill_Slot.Save_nowSkill();

            // 오브정보를 무기의 Equipped_Obes(장착된 오브들)에 전달
            Weapon_Slot.myWeapon.Equipped_Obes[SlotNum] = Obe2D.transform;

            // 스킬 슬롯이 '비어있지 않음'을 설정
            mySkill_Slot.isEmpty = false;
        }
    }

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
        obj.transform.SetAsFirstSibling();
        mySkill_Slot.Save_nowSkill();

        // 오브정보를 무기의 Equipped_Obes(장착된 오브들)에 전달
        Weapon_Slot.myWeapon.Equipped_Obes[SlotNum] = Obe2D.transform;

        // 스킬 슬롯이 '비어있지 않음'을 설정
        mySkill_Slot.isEmpty = false;
    }
}
