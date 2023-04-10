using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2D_isQuantity : Item_2D
{
    public override void QuantityOnOff_ofBeforeSlot(bool b)
    {
        Before_Slot.GetComponent<ItemSlot_isQuantity>().QuantityArea.SetActive(b);
    }
}
