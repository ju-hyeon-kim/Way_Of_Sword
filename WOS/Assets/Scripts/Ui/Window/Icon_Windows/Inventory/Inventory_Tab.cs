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

    public void Save_ItemData(SaveData saveData)
    {
        for (int i = 0; i < mySlots.Length; i++)
        {
            if (mySlots[i].myItem != null)
            {
                saveData.ItemType.Add((int)myType); // ������Ÿ�� ����
                saveData.ItemSlot.Add(i); // ���Թ�ȣ ����
                saveData.ItemID.Add(mySlots[i].myItem.myData.ID); // ID����
                int q = 1;
                if (mySlots[i].myItem.GetComponent<Item2D_isQuantity>() != null)
                {
                    q = mySlots[i].GetComponent<ItemSlot_isQuantity>().Quantity;
                }
                saveData.ItemQuantity.Add(q);
            }
        }
    }

    public void Load_ItemData(SaveData savedata, int count)
    {
        Item_2D item2D = Dont_Destroy_Data.Inst.Manager_Item.ItemList[savedata.ItemID[count]].GetComponent<Item_2D>();
        mySlots[savedata.ItemSlot[count]].Put_NewItem(item2D, savedata.ItemQuantity[count]);
    }

    public void RemoveAll_Item()
    {
        for (int i = 0; i < mySlots.Length; i++)
        {
            if (mySlots[i].myItem != null)
            {
                Destroy(mySlots[i].myItem.gameObject);
                mySlots[i].isNoneItem();
            }
        }
    }
}