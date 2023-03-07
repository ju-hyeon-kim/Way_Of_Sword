using UnityEngine;

public class Inventory_Tab : MonoBehaviour
{
    public Inventory_Slot[] mySlots;
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
                    if(myType != ItemType.Equipment || myType != ItemType.Obe) // ���or���� Ÿ���� �ƴ϶��
                    {
                        mySlots[i].Put_SameItem(); 
                        break;
                    }
                    else // ���or����� ���� �������� �־ �ٸ��� �ν��ؾ���
                    {
                        isNoneSameItem = true;
                    }
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

        if (isEmptyAllSlot || isNoneSameItem) // ������ ���� ����ְų� ���� �̸��� �������� ���ٸ�
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

        if (isFullAllSlot)
        {
            Debug.Log("�κ��丮�� ���� á���ϴ�.");
        }
    }
}
