using UnityEngine;

public class Equipment_Tap : MonoBehaviour
{
    public Item_Slot[] Slots;

    public float AddAp() // �߰����ݷ�
    {
        Weapon_Slot ws = Slots[0] as Weapon_Slot;
        return ws.Get_WeaponAp();
    }

    public float AddDp() // �߰� ����
    {
        float TotalAddDp = 0;
        // ���߿� ���� 1~7 ���� �˻��Ͽ� ���� ������ ���� �ʿ�
        for(int i = 1; i < Slots.Length; i++)
        {
            Armor_Slot ArmorSlot = Slots[i] as Armor_Slot;
            TotalAddDp += ArmorSlot.Get_ArmorDp();
        }
        return TotalAddDp;
    }
}
