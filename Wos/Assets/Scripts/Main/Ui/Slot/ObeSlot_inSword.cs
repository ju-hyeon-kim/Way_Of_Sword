using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObeSlot_inSword : Item_Slot
{
    public ItemType SlotType = default; // �ν����Ϳ��� ������
    public Weapon_Slot Weapon_Slot;
    public Skill_Slot mySkill_Slot;
    public int SlotNum;

    public void StartSetting() // SwordIcon_Window�� Start()���� �����
    {
        if(this.transform.childCount > 0) // �ڽ��� �ִٸ�
        {
            // ��ų���Կ� ��ų ����
            Obe_2D Obe2D = this.transform.GetChild(0).GetComponent<Obe_2D>();
            Obe_Data ObeData = Obe2D.myData as Obe_Data;

            GameObject obj = Instantiate(ObeData.Skill_2D.gameObject, mySkill_Slot.transform);
            obj.transform.SetAsFirstSibling();
            mySkill_Slot.Save_nowSkill();

            // ���������� ������ Equipped_Obes(������ �����)�� ����
            Weapon_Slot.myWeapon.Equipped_Obes[SlotNum] = Obe2D.transform;

            // ��ų ������ '������� ����'�� ����
            mySkill_Slot.isEmpty = false;
        }
    }

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
        obj.transform.SetAsFirstSibling();
        mySkill_Slot.Save_nowSkill();

        // ���������� ������ Equipped_Obes(������ �����)�� ����
        Weapon_Slot.myWeapon.Equipped_Obes[SlotNum] = Obe2D.transform;

        // ��ų ������ '������� ����'�� ����
        mySkill_Slot.isEmpty = false;
    }
}
