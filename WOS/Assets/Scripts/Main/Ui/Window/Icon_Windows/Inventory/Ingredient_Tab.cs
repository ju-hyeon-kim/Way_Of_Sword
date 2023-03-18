using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient_Tab : Inventory_Tab
{
    public int Get_HaveAmount_MagicStone()
    {
        int HaveAmount = 0;
        for (int i = 0; i < mySlots.Length; i++)
        {
            if (mySlots[i].myItem != null) // 비어있지않으면
            {
                if (mySlots[i].myItem.myData.Name == "마석") // 마석이 있다면
                {
                    HaveAmount = mySlots[i].GetComponent<ItemSlot_isQuantity>().Quantity;
                    break;
                }
                else // 전부 마석이 아니라면
                {
                    HaveAmount = 0;
                }
                
            }
            else // 전부 비어있으면
            {
                HaveAmount = 0; ;
            }
        }
        return HaveAmount;
    }
}
