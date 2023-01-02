using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwordObe_Slot : Item_Slot
{
    public Item.Type SlotType = default; // �ν����Ϳ��� ������
    public Transform mySkill_Slot;
    public Transform myWeapon_Slot;
    public int mySlotNum;

    public override bool TypeDetect(PointerEventData eventData)
    {
        //�������� Ÿ���� ������ true�� ��ȯ, �ƴϸ� false�� ��ȯ

        if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == SlotType)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void DropEvent(PointerEventData eventData)
    {
        Transform ED = eventData.pointerDrag.transform;
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        ED.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 0��° �ڽ����� ����
        ED.SetAsFirstSibling();

        // ������ Equipment_Data.Equipped_Obes �� ����


        //�κ��丮�κ��� ���긦 �޾��� ��
        // ��ų��(�������̽�)�� ����
        ED.GetComponent<Obe_Icon>().SkillSet_Conection();
        // ����� ����
        myWeapon_Slot.GetChild(1).GetComponent<Equipment_Icon>().Equipment_Data.Equipped_Obes[mySlotNum] = ED.GetComponent<Obe_Icon>().Obe_Data;
    }
}
