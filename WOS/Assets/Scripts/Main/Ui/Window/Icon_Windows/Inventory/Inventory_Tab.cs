using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Tab : Icon_Window
{
    public Inven_Slot[] mySlots;
    public ItemType myType;

    public void Put_Item(Item_2D item)
    {
        bool isEmptyAllSlot = false;
        bool isNoneSameItem = false;
        bool isFullAllSlot = false;

        for (int i = 0; i < mySlots.Length; i++)
        {
            if (!mySlots[i].isEmpty) // �������������
            {
                isEmptyAllSlot = false;
                if (mySlots[i].Get_myItemName() == item.myData.Name) // ���� �������� �ִٸ�
                {
                    isNoneSameItem = false;
                    mySlots[i].Put_SameItem();
                    break;
                }
                else // ���� �������� �ƴ϶��
                {
                    isNoneSameItem = true;
                }
            }
            else // ���������
            {
                isEmptyAllSlot = true;
            }
        }

        if(isEmptyAllSlot || isNoneSameItem) // ������ ���� ����ְų� ���� �̸��� �������� ���ٸ�
        {
            for (int i = 0; i < mySlots.Length; i++) // ����ִ� �����߿� ���� ù ���Կ� �ִ´�.
            {
                if (mySlots[i].isEmpty)
                {
                    isFullAllSlot = false;
                    mySlots[i].Put_NewItem(item);
                    break;
                }
                else
                {
                    isFullAllSlot = true;
                }
            }
        }

        if(isFullAllSlot)
        {
            Debug.Log("�κ��丮�� ���� á���ϴ�.");
        }
    }
}
