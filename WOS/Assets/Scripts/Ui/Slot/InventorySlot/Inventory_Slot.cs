using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

public class Inventory_Slot : Item_Slot
{
    public ItemType myType;

    public override bool isSameType(Item_2D NewItem2D)
    {
        if (myType == NewItem2D.myData.ItemType)
        {
            return true;
        }
        return false;
    }
}
