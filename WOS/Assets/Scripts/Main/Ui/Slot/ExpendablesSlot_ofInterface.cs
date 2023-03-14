using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpendablesSlot_ofInterface : ItemSlot_isQuantity
{
    private void Start() // ���ǻ�� �׽�Ʈ ��
    {
        if(myItem != null)
        {
            Quantity = 1;
            QuantityArea.SetActive(true);
        }
    }

    public override void Quantity_isZero()
    {
        if(Quantity == 0)
        {
            Destroy(myItem.gameObject);
            QuantityArea.SetActive(false);
            myItem = null;
        }
    }
}
