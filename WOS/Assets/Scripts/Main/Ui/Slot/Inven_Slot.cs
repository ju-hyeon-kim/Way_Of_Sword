using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

public class Inven_Slot : Item_Slot
{
    public ItemType SlotType = default; // 인스펙터에서 정해줌
    public bool isEmpty = true;
    public TMP_Text myQuantity_Text;

    Item_2D myItem;
    int Quantity = 0;

    //public override bool TypeDetect(PointerEventData eventData)
    
        /*//아이템의 타입이 슬롯 타입과 같다면 true를 반환, 아니면 false를 반환
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

        // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
        myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // 오브제는 슬롯의 0번째 자식으로 설정
        myItem.transform.SetAsFirstSibling();
        // 수량 가져오기
        Quantity = myItem.GetComponent<Item_2D>().Before_Parents.GetComponent<Inven_Slot>().Quantity;
        myQuantity_Text.text = Quantity.ToString();
        myQuantity_Text.transform.parent.gameObject.SetActive(true);
        myItem.GetComponent<Item_2D>().Before_Parents.GetComponent<Inven_Slot>().isNone_Item();


        // 타입별로 다른 작동
        switch (SlotType)
        {
            case ItemType.Equipment: //장비를 받았을 때
                {
                    if(myItem.GetComponent<Item_2D>().Before_Parents.name == "Weapon")
                    {
                        myItem.GetComponent<Item_2D>().Before_Parents.GetComponent<Weapon_Slot>().Equip_Control(); //무기장착해제
                    }
                }
                break;
            case ItemType.Obe: //오브를 받았을 때
                {
                    Obe_2D myObe = myItem.GetComponent<Obe_2D>();
                    
                    //장착되어 있던 무기와 연동
                    if(myObe.Before_Parents.parent.name == "SwordObe_Slots")// 소드오브슬롯으로부터 받았을 때
                    {
                        //스킬셋에 스킬데이터 건네주기

                        //오브 장착 해제
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
        Obj.transform.SetAsFirstSibling(); // 첫번째 자식으로 변경

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

    public void isNone_Item() // 아이템이 없을 때
    {
        Quantity = 0;
        myQuantity_Text.transform.parent.gameObject.SetActive(false);
    }
}
