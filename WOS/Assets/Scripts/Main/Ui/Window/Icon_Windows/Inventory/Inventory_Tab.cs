using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Tab : Icon_Window
{
    public Inven_Slot[] mySlots;
    public ItemType myType;

    public void Put_Item(Item_2D item)
    {
        //�� ���� ã��
        for (int i = 0; i < mySlots.Length; i++)
        {
            if (mySlots[i].isEmpty)
            {
                mySlots[i].Put_Item(item);
                break;
            }
        }
    }
}
