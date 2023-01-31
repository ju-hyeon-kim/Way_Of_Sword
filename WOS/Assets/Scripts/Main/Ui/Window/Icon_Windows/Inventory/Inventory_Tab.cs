using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Tab : Icon_Window
{
    public Inven_Slot[] mySlots;
    public ItemType myType;

    public void Put_Item(Item_2D item)
    {
        for (int i = 0; i < mySlots.Length; i++)
        {
            if (!mySlots[i].isEmpty) // 비어 있지 않으면
            {
                // 같은 아이템인지 확인
                if (mySlots[i].Get_myItemName() == item.myData.Name)
                {
                    mySlots[i].Put_SameItem();
                    break;
                }
                // 같은 아이템이 없으면
                for (int j = 0; j < mySlots.Length; j++) // 비어있는 슬롯중에 가장 첫 슬롯에 넣는다.
                {
                    if(mySlots[j].isEmpty)
                    {
                        mySlots[j].Put_NewItem(item);
                        break;
                    }
                }
                break;
            }

            
            //전부 비어있으면
            for (int j = 0; j < mySlots.Length; j++) // 비어있는 슬롯중에 가장 첫 슬롯에 넣는다.
            {
                if (mySlots[j].isEmpty)
                {
                    mySlots[j].Put_NewItem(item);
                    break;
                }
            }
            break;
        }
    }
}
