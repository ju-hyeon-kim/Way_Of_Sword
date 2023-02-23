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
        if (!isEmpty) // ������ ������� �ʴٸ�
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
            // ���� -> ���� ���� ������ ���⿡ ���ε� �Ǿ��ִ� ���갡 ������ -> ���� ������ ��������� �ƴ϶� ���긦 ������ �ڽ����� ��ġ�� unactive obeject�� setparent ���Ѽ� ���� �ʿ�
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
