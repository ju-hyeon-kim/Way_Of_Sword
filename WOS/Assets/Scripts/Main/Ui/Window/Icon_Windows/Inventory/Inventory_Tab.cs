using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Tab : Icon_Window
{
    public Inven_Slot[] mySlots;
    public ItemType myType;

    public void Put_Item(Item_2D item)
    {
        bool isEmptyAllSlot = false;
        bool isNoneSameItem = false;
        bool isFullAllSlot = false;

        for (int i = 0; i < mySlots.Length; i++)
        {
            if (!mySlots[i].isEmpty) // 비어있지않으면
            {
                isEmptyAllSlot = false;
                if (mySlots[i].Get_myItemName() == item.myData.Name) // 같은 아이템이 있다면
                {
                    isNoneSameItem = false;
                    mySlots[i].Put_SameItem();
                    break;
                }
                else // 같은 아이템이 아니라면
                {
                    isNoneSameItem = true;
                }
            }
            else // 비어있으면
            {
                isEmptyAllSlot = true;
            }
        }

        if(isEmptyAllSlot || isNoneSameItem) // 슬롯이 전부 비어있거나 같은 이름의 아이템이 없다면
        {
            for (int i = 0; i < mySlots.Length; i++) // 비어있는 슬롯중에 가장 첫 슬롯에 넣는다.
            {
                if (mySlots[i].isEmpty)
                {
                    isFullAllSlot = false;
                    mySlots[i].Put_NewItem(item);
                    break;
                }
                else
                {
                    isFullAllSlot = true;
                }
            }
        }

        if(isFullAllSlot)
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
    }
}
