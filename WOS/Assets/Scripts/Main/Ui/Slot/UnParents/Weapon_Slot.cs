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
        if (myItem != null) // 슬롯이 비어있지 않다면
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

        //오브 세팅
        for (int i = 0; i < weapon.Equipped_Obes.Length; i++)
        {
            // 오류 -> 무기 장착 해제시 무기에 바인딩 되어있는 오브가 삭제됨 -> 장착 해제시 오브삭제가 아니라 오브를 무기의 자식으로 위치한 unactive obeject에 setparent 시켜서 보관 필요
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

    public override void Change_Item(Item_2D beforeItem, Item_2D newItem) // 슬롯에 이미 아이템이있는데 다른아이템을 드랍받으려 한다면
    {
        //3D무기교체
        Player player = Dont_Destroy_Data.Inst.Player.GetComponent<Player>();
        Weapon_2D BeforeWeapon2D = beforeItem as Weapon_2D;
        player.myWeapon_3D.SetParent(BeforeWeapon2D.myWeapon_3D);
        Weapon_2D NewWeapon2D = newItem as Weapon_2D;
        myWeapon = NewWeapon2D;
        Transform NewWeapon3D = NewWeapon2D.myWeapon_3D.GetChild(0);
        NewWeapon3D.SetParent(player.Parents_of_Weapon[0]);
        NewWeapon3D.transform.localPosition = Vector3.zero;
        NewWeapon3D.transform.localRotation = Quaternion.identity;

        //2D무기교체
        //beforeItem
        beforeItem.transform.SetParent(newItem.Before_Slot.transform);
        beforeItem.transform.SetAsFirstSibling();
        beforeItem.transform.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
        beforeItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // 사이즈 슬롯에 맞게 설정
        //newItem
        newItem.transform.SetParent(this.transform);
        newItem.transform.SetAsFirstSibling();
        newItem.transform.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
        newItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // 사이즈 슬롯에 맞게 설정
    }
}