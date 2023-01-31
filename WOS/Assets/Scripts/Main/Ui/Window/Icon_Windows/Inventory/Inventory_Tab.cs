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
            if (!mySlots[i].isEmpty) // ��� ���� ������
            {
                // ���� ���������� Ȯ��
                if (mySlots[i].Get_myItemName() == item.myData.Name)
                {
                    mySlots[i].Put_SameItem();
                    break;
                }
                // ���� �������� ������
                for (int j = 0; j < mySlots.Length; j++) // ����ִ� �����߿� ���� ù ���Կ� �ִ´�.
                {
                    if(mySlots[j].isEmpty)
                    {
                        mySlots[j].Put_NewItem(item);
                        break;
                    }
                }
                break;
            }

            
            //���� ���������
            for (int j = 0; j < mySlots.Length; j++) // ����ִ� �����߿� ���� ù ���Կ� �ִ´�.
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
