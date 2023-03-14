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
        if (myItem != null) // ������ ������� �ʴٸ�
        {
            Weapon_Data weaponData = (Weapon_Data)myWeapon.myData;
            return weaponData.Ap;
        }
        else
        {
            return 0;
        }
    }

    /*public override void OnDrop_ofChild(PointerEventData eventData)
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
    }*/

    public override void isNoneItem_ofChild()
    {
        for (int i = 0; i < SwordObe_Slots.Length; i++)
        {
            if (SwordObe_Slots[i].myItem != null)
            {
                SwordObe_Slots[i].Unequipment_Weapon();
            }
        }
    }

    public override void Change_Item(Item_2D beforeItem, Item_2D newItem) // ���Կ� �̹� ���������ִµ� �ٸ��������� ��������� �Ѵٸ�
    {
        //3D���ⱳü
        Player player = Dont_Destroy_Data.Inst.Player.GetComponent<Player>();
        Weapon_2D BeforeWeapon2D = beforeItem as Weapon_2D;
        player.myWeapon_3D.SetParent(BeforeWeapon2D.myWeapon_3D);
        Weapon_2D NewWeapon2D = newItem as Weapon_2D;
        myWeapon = NewWeapon2D;
        Transform NewWeapon3D = NewWeapon2D.myWeapon_3D.GetChild(0);
        NewWeapon3D.SetParent(player.Parents_of_Weapon[0]);
        NewWeapon3D.transform.localPosition = Vector3.zero;
        NewWeapon3D.transform.localRotation = Quaternion.identity;

        //2D���ⱳü
        //beforeItem
        beforeItem.transform.SetParent(newItem.Before_Slot.transform);
        beforeItem.transform.SetAsFirstSibling();
        beforeItem.transform.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
        beforeItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // ������ ���Կ� �°� ����
        //newItem
        newItem.transform.SetParent(this.transform);
        newItem.transform.SetAsFirstSibling();
        newItem.transform.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
        newItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // ������ ���Կ� �°� ����
    }
}