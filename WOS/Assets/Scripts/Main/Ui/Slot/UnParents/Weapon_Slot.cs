using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon_Slot : Equipment_Slot
{
    [Header("-----Weapon_Slot-----")]
    public Player Player;
    public Skill_Set Skill_Set;
    public ObeSlot_inSword[] SwordObe_Slots = new ObeSlot_inSword[4];
    public Weapon_2D myWeapon;

    public float Get_WeaponAp()
    {
        if (!isEmpty) // 슬롯이 비어있지 않다면
        {
            Weapon_Data weaponData = (Weapon_Data)myWeapon.myData;
            return weaponData.Ap;
        }
        else
        {
            return 0;
        }
    }

    public override void OnDrop_ofChild(PointerEventData eventData)
    {
        Weapon_2D weapon = myItem as Weapon_2D;
        for (int i = 0; i < weapon.Equipped_Obes.Length; i++)
        {
            // 오류 -> 무기 장착 해제시 무기에 바인딩 되어있는 오브가 삭제됨 -> 장착 해제시 오브삭제가 아니라 오브를 무기의 자식으로 위치한 unactive obeject에 setparent 시켜서 보관 필요
            if (weapon.Equipped_Obes[i].TryGetComponent<Obe_2D>(out Obe_2D component))
            {
                SwordObe_Slots[i].Receive_toWeaponSlot(component);
            }
        }
    }

    public override void isNone_Item()
    {
        for (int i = 0; i < SwordObe_Slots.Length; i++)
        {
            if (!SwordObe_Slots[i].isEmpty)
            {
                SwordObe_Slots[i].Unequipment_Weapon();
            }
        }
        isEmpty = true;
    }
}
