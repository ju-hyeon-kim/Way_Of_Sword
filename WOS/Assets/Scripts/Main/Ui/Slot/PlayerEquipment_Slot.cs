using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerEquipment_Slot : Item_Slot
{
    // �ν����Ϳ��� ������
    public ItemType ItmeType_slot = default; 
    public EquipmentType EquipmentType_slot = default;


    public override void DropEvent(PointerEventData eventData)
    {
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 2��° �ڽ����� ����
        eventData.pointerDrag.transform.SetSiblingIndex(1);

        if(EquipmentType_slot == EquipmentType.Weapon)
        {
            transform.GetComponent<Weapon_Slot>().Equip_Control();
        }
    }

    /*public override bool TypeDetect(PointerEventData eventData)
    {
        *//*Transform II = eventData.pointerDrag.transform;
        //�������� Ÿ���� ���� Ÿ�԰� ���ٸ� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (II.GetComponent<Item_2D>().myType == ItmeType_slot && II.GetComponent<Item_2D>().myData. .Equipment_Data.EquipmentType == EquipmentType_slot)
        {
            return true;
        }
        else
        {
            return false;
        }*//*
    }*/

}
