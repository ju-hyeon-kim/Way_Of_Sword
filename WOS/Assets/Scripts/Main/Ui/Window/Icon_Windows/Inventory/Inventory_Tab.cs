using UnityEngine;

public class Inventory_Tab : MonoBehaviour
{
    public Item_Slot[] mySlots;
    public ItemType myType;

    public void Put_Item(Item_2D item)
    {
        bool isEmptyAllSlot = false;
        bool isNoneSameItem = false; // true = ���� �̸��� �������� ���� 

        for (int i = 0; i < mySlots.Length; i++)
        {
            if (mySlots[i].myItem != null) // �������������
            {
                if (mySlots[i].myItem.myData.Name == item.myData.Name) // ���� �������� �ִٸ�
                {
                    if (myType == ItemType.Expendables || myType == ItemType.Ingredient) // �Ҹ�ǰor��� Ÿ���̶��
                    {
                        ++mySlots[i].GetComponent<ItemSlot_isQuantity>().Quantity;
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
                if (mySlots[i].myItem == null)
                {
                    mySlots[i].Put_NewItem(item);
                    break;
                }
                else
                {
                    Debug.Log("�κ��丮�� ���� á���ϴ�.");
                }
            }
        }
    }
}