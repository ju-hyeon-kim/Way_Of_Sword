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
            if (mySlots[i].myItem != null) // �������������
            {
                if (mySlots[i].myItem.myData.Name == "����") // ������ �ִٸ�
                {
                    HaveAmount = mySlots[i].GetComponent<ItemSlot_isQuantity>().Quantity;
                    break;
                }
                else // ���� ������ �ƴ϶��
                {
                    HaveAmount = 0;
                }
                
            }
            else // ���� ���������
            {
                HaveAmount = 0; ;
            }
        }
        return HaveAmount;
    }
}
