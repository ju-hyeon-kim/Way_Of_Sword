using UnityEngine;

public class Equipment_Tap : MonoBehaviour
{
    public Item_Slot[] Slots;

    public float AddAp() // 추가공격력
    {
        Weapon_Slot ws = Slots[0] as Weapon_Slot;
        return ws.Get_WeaponAp();
    }

    public float AddDp() // 추가 방어력
    {
        float TotalAddDp = 0;
        // 나중에 슬롯 1~7 까지 검사하여 방어력 빼오기 구현 필요
        for(int i = 1; i < Slots.Length; i++)
        {
            Armor_Slot ArmorSlot = Slots[i] as Armor_Slot;
            TotalAddDp += ArmorSlot.Get_ArmorDp();
        }
        return TotalAddDp;
    }
}
