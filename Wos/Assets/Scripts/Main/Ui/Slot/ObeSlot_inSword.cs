using UnityEngine;
using UnityEngine.EventSystems;

public class ObeSlot_inSword : Item_Slot
{
    public Weapon_Slot Weapon_Slot;
    public Skill_Slot mySkill_Slot;
    public int SlotNum;
    public Obe_2D myObe;

    public void StartSetting() // SwordIcon_Window의 Start()에서 실행됨
    {
        if (this.transform.childCount > 0) // 자식이 있다면
        {
            // 스킬슬롯에 스킬 전달
            myObe = this.transform.GetChild(0).GetComponent<Obe_2D>();
            Obe_Data ObeData = myObe.myData as Obe_Data;

            GameObject obj = Instantiate(ObeData.Skill_2D.gameObject, mySkill_Slot.transform);
            obj.transform.SetAsFirstSibling();
            mySkill_Slot.Save_nowSkill();

            // 오브정보를 무기의 Equipped_Obes(장착된 오브들)에 전달
            Weapon_Slot.myWeapon.Equipped_Obes[SlotNum] = myObe.transform;

            // 스킬 슬롯이 '비어있지 않음'을 설정
            mySkill_Slot.isEmpty = false;
        }
    }

    public override void OnDrop_ofChild(PointerEventData eventData) // DragDrop으로 오브를 받았을 때
    {
        myObe = eventData.pointerDrag.GetComponent<Obe_2D>();
        Receive_Obe();
    }

    public void ReceiveObe_fromWeapon(Obe_2D Obe2D) // Weapon의 장착으로 오브를 받았을 때
    {
        myObe = Obe2D;
        Receive_Obe();
    }

    void Receive_Obe()
    {
        // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
        myObe.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        // 오브제는 슬롯의 0번째 자식으로 설정
        myObe.transform.SetAsFirstSibling();

        // 스킬슬롯에 스킬 전달
        Obe_Data ObeData = myObe.myData as Obe_Data;
        GameObject obj = Instantiate(ObeData.Skill_2D.gameObject, mySkill_Slot.transform);
        obj.transform.SetAsFirstSibling();
        mySkill_Slot.Save_nowSkill();

        // 오브정보를 무기의 Equipped_Obes(장착된 오브들)에 전달
        Weapon_Slot.myWeapon.Equipped_Obes[SlotNum] = myObe.transform;

        // 스킬 슬롯이 '비어있지 않음'을 설정
        mySkill_Slot.isEmpty = false;
    }

    public override void isNone_Item() // 오브 장착해제
    {
        //해당 슬롯에 연결된 스킬 삭제 -> 추후에 오브젝트 풀링 적용 필요
        mySkill_Slot.isNone_Skill();
        isEmpty = true;
    }

    public void Unequipment_Weapon()
    {
        Destroy(myObe.gameObject);
        myObe = null;
        isNone_Item();
        isEmpty = true;
    }
}
