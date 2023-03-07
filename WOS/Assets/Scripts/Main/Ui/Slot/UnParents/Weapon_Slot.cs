using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon_Slot : EquipmentSlot_ofPlayerWindow
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

        //���� ����
        for (int i = 0; i < weapon.Equipped_Obes.Length; i++)
        {
            // ���� -> ���� ���� ������ ���⿡ ���ε� �Ǿ��ִ� ���갡 ������ -> ���� ������ ��������� �ƴ϶� ���긦 ������ �ڽ����� ��ġ�� unactive obeject�� setparent ���Ѽ� ���� �ʿ�
            if (weapon.Equipped_Obes[i] != null)
            {
                Obe_2D Obe2D = weapon.Equipped_Obes[i].GetComponent<Obe_2D>();
                SwordObe_Slots[i].ReceiveObe_fromWeapon(Obe2D);
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

    public override void Slot_is_not_empty() // ���Կ� �̹� ���������ִµ� �ٸ��������� ��������� �Ѵٸ�
    {
        //���⸦ ��ü �Ͻðڽ��ϱ�?
        Question_Window QW = Dont_Destroy_Data.Inst.Question_Window;
        QW.Text.text = "���⸦ ��ü�Ͻðڽ��ϱ�?";
        QW.gameObject.SetActive(true);
    }
}
