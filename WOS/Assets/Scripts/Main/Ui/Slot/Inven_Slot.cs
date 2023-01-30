using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inven_Slot : Item_Slot
{
    public ItemType SlotType = default; // �ν����Ϳ��� ������
    public bool isEmpty = true;

    public override bool TypeDetect(PointerEventData eventData)
    {
        //�������� Ÿ���� ���� Ÿ�԰� ���ٸ� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (eventData.pointerDrag.transform.GetComponent<Item_2D>().myType == SlotType)
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
        Transform myItem = eventData.pointerDrag.transform;
        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 0��° �ڽ����� ����
        myItem.transform.SetAsFirstSibling();
        // ���� �����̶��
        switch(SlotType)
        {
            case ItemType.Equipment: //��� �޾��� ��
                {
                    if(myItem.GetComponent<Equipment_2D>().Before_Parents.name == "Weapon")
                    {
                        myItem.GetComponent<Equipment_2D>().Before_Parents.GetComponent<Weapon_Slot>().Equip_Control(); //������������
                    }
                }
                break;
            case ItemType.Obe: //���긦 �޾��� ��
                {
                    Obe_2D myObe = myItem.GetComponent<Obe_2D>();
                    
                    //�����Ǿ� �ִ� ����� ����
                    if(myObe.Before_Parents.parent.name == "SwordObe_Slots")// �ҵ���꽽�����κ��� �޾��� ��
                    {
                        //��ų�¿� ��ų������ �ǳ��ֱ�
                        myObe.Give_Skill_Data();
                        //���� ���� ����
                        int Obe_Num = myObe.Before_Parents.GetComponent<SwordObe_Slot>().mySlotNum;
                        Transform myWeapon = myObe.Before_Parents.GetComponent<SwordObe_Slot>().myWeapon_Slot.GetChild(1);

                        myWeapon.GetComponent<Item_2D>().myData.GetComponent<Equipment_Data>().Equipped_Obes[Obe_Num] = null;
                    }
                }
                break;
        }
    }

    public void Put_Item(Item_2D item)
    {
        Debug.Log(gameObject.name);
        GameObject Obj = Instantiate(item.gameObject, transform) as GameObject;
        Obj.transform.SetAsFirstSibling(); // ù��° �ڽ����� ����
    }
}
