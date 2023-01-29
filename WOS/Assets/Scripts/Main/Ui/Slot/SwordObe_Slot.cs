using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwordObe_Slot : Item_Slot
{
    public Item_Types.ItemType SlotType = default; // �ν����Ϳ��� ������
    public Transform mySkill_Icon;
    public Transform myWeapon_Slot;
    public Skill_Set mySkill_Set;
    public int mySlotNum;

    public override bool TypeDetect(PointerEventData eventData)
    {
        //�������� Ÿ���� ������ true�� ��ȯ, �ƴϸ� false�� ��ȯ

        if (eventData.pointerDrag.transform.GetComponent<Item_2D>().myType == SlotType)
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
        Transform ED = eventData.pointerDrag.transform;

        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        ED.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 0��° �ڽ����� ����
        ED.SetAsFirstSibling();
        // ��ų�¿� ��ų ������ �ǳ��ֱ�
        ED.GetComponent<Obe_2D>().Give_Skill_Data();
        // ������ '������ �����(Equipped_Obes)'�� ����
        //myWeapon_Slot.GetChild(1).GetComponent<Equipment_2D>().Equipment_Data.Equipped_Obes[mySlotNum] = ED.GetComponent<Obe_2D>().Obe_Data;

        // ���� �ҵ������ �������� ��Ȳ�� �°� '������ �����(Equipped_Obes)' ���� = �ٸ� �ҵ���꽽�Կ��� ���긦 �޾��� ��
        // + ��ų�µ� ����
        for(int i = 0; i < 4; i++)
        {
            if (transform.parent.GetChild(i).childCount == 0) //�ҵ���꽽���� �ڽ��� ���ٸ�
            {
                myWeapon_Slot.GetChild(1).GetComponent<Equipment_2D>().Equipment_Data.Equipped_Obes[i] = null;
                mySkill_Set.Skill_Icons[i].SetActive(false);
            }
        }
    }
}
