using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

public class Inven_Slot : Item_Slot
{
    public ItemType SlotType = default; // �ν����Ϳ��� ������
    public bool isEmpty = true;
    public TMP_Text myQuantity_Text;

    Item_2D myItem;
    int Quantity = 0;

    //public override bool TypeDetect(PointerEventData eventData)
    
        /*//�������� Ÿ���� ���� Ÿ�԰� ���ٸ� true�� ��ȯ, �ƴϸ� false�� ��ȯ
        if (eventData.pointerDrag.transform.GetComponent<Item_2D>().myType == SlotType)
        {
            return true;
        }
        else
        {
            return false;
        }*/
    

    public override void DropEvent(PointerEventData eventData)
    {
        Transform myItem = eventData.pointerDrag.transform;

        // �������� �������� �� �������� ũ�Ⱑ ���Կ� �°� �پ��
        myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // �������� ������ 0��° �ڽ����� ����
        myItem.transform.SetAsFirstSibling();
        // ���� ��������
        Quantity = myItem.GetComponent<Item_2D>().Before_Parents.GetComponent<Inven_Slot>().Quantity;
        myQuantity_Text.text = Quantity.ToString();
        myQuantity_Text.transform.parent.gameObject.SetActive(true);
        myItem.GetComponent<Item_2D>().Before_Parents.GetComponent<Inven_Slot>().isNone_Item();


        // Ÿ�Ժ��� �ٸ� �۵�
        switch (SlotType)
        {
            case ItemType.Equipment: //��� �޾��� ��
                {
                    if(myItem.GetComponent<Item_2D>().Before_Parents.name == "Weapon")
                    {
                        myItem.GetComponent<Item_2D>().Before_Parents.GetComponent<Weapon_Slot>().Equip_Control(); //������������
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

                        //���� ���� ����
                        //int Obe_Num = myObe.Before_Parents.GetComponent<SwordObe_Slot>().mySlotNum;
                        //Transform myWeapon = myObe.Before_Parents.GetComponent<SwordObe_Slot>().myWeapon_Slot.GetChild(1);

                        //myWeapon.GetComponent<Item_2D>().myData.GetComponent<Equipment_Data>().Equipped_Obes[Obe_Num] = null;
                    }
                }
                break;
        }
    }

    public void Put_NewItem(Item_2D item)
    {
        GameObject Obj = Instantiate(item.gameObject, transform) as GameObject;
        Obj.transform.SetAsFirstSibling(); // ù��° �ڽ����� ����

        Quantity++;
        myQuantity_Text.text = $"{Quantity}";
        myQuantity_Text.transform.parent.gameObject.SetActive(true);
        myItem = Obj.GetComponent<Item_2D>();
        isEmpty = false;
    }

    public void Put_SameItem()
    {
        Quantity++;
        myQuantity_Text.text = $"{Quantity}";
    }

    public string Get_myItemName()
    {
        return myItem.myData.Name;
    }

    public void isNone_Item() // �������� ���� ��
    {
        Quantity = 0;
        myQuantity_Text.transform.parent.gameObject.SetActive(false);
    }
}
