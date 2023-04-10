using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSlot_isQuantity : Item_Slot
{
    [Header("-----ItemSlot_isQuantity-----")]
    public GameObject QuantityArea;
    public TMP_Text QuantityText;

    int quantity = 0;
    public int Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            quantity = value;
            Quantity_isZero();
            QuantityText.text = $"{quantity}";
        }
    }

    public override void isNoneItem_ofChild() // 아이템이 없을 때
    {
        quantity = 0;
    }

    public override void GetQuantity_fromBeforslot(Item_Slot BeforeSlot)
    {
        int Quntitiy_ofBeforeSlot = BeforeSlot.GetComponent<ItemSlot_isQuantity>().Quantity;
        this.Quantity = Quntitiy_ofBeforeSlot;
        QuantityArea.SetActive(true);
    }

    public virtual void Quantity_isZero() { }
}
