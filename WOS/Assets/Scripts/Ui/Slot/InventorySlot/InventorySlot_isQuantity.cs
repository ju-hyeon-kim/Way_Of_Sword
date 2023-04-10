using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot_isQuantity : ItemSlot_isQuantity
{
    public ItemType myType;

    public override bool isSameType(Item_2D NewItem2D)
    {
        if(myType == NewItem2D.myData.ItemType)
        {
            return true;
        }
        return false;
    }
}
