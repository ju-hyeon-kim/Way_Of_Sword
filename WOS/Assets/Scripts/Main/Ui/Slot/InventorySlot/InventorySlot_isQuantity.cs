using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot_isQuantity : ItemSlot_isQuantity
{
    public override void Put_NewQuantityItem()
    {
        Quantity = 1;
        QuantityArea.SetActive(true);
    }
}
