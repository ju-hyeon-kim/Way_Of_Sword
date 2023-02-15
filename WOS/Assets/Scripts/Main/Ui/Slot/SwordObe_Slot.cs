using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwordObe_Slot : Item_Slot
{
    public ItemType SlotType = default; // �ν����Ϳ��� ������
    public Weapon_Slot Weapon_Slot;
    public Skill_Slot mySkill_Slot;

    public override bool TypeDetect(PointerEventData eventData)
    {
        //�������� Ÿ���� ������ true�� ��ȯ, �ƴϸ� false�� ��ȯ

        if (eventData.pointerDrag.transform.GetComponent<Item_2D>().myData.ItemType == SlotType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void DropEvent(PointerEventData eventData) //���긦 �޾��� ��
    {
        Obe_2D Obe2D = eventData.pointerDrag.GetComponent<Obe_2D>();

        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        Obe2D.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        // �������� ������ 0��° �ڽ����� ����
        Obe2D.transform.SetAsFirstSibling();

        // ��ų���Կ� ��ų ����
        Obe_Data ObeData = Obe2D.myData as Obe_Data;
        GameObject obj = Instantiate(ObeData.Skill_2D.gameObject, mySkill_Slot.transform);

        // ������ '������ �����(Equipped_Obes)'�� ����
        for(int i = 0; i < Weapon_Slot.SwordObe_Slots.Length; i++)
        {
            if (Weapon_Slot.SwordObe_Slots[i] == this)
            {
                Weapon_Data WeaponData = Weapon_Slot.myWeapon.myData as Weapon_Data;
                WeaponData.Equipped_Obes[i] = ObeData;
            }
        }
    }
}
