using UnityEngine;

public class Equipment_Tap : MonoBehaviour
{
    public Item_Slot[] Slots;

    public float AddAp()
    {
        Weapon_Slot ws = Slots[0] as Weapon_Slot;
        return ws.Get_WeaponAp();
    }

    public float AddDp()
    {
        // 나중에 슬롯 1~7 까지 검사하여 방어력 빼오기 구현 필요
        return 0;
    }
}
