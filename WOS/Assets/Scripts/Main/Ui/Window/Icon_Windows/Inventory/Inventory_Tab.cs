using UnityEngine;

public class Inventory_Tab : MonoBehaviour
{
    public Item_Slot[] mySlots;
    public ItemType myType;

    public void Put_Item(Item_2D item)
    {
        bool isEmptyAllSlot = false;
        bool isNoneSameItem = false; // true = 같은 이름의 아이템이 없다 

        for (int i = 0; i < mySlots.Length; i++)
        {
            if (mySlots[i].myItem != null) // 비어있지않으면
            {
                if (mySlots[i].myItem.myData.Name == item.myData.Name) // 같은 아이템이 있다면
                {
                    if (myType == ItemType.Expendables || myType == ItemType.Ingredient) // 소모품or재료 타입이라면
                    {
                        ++mySlots[i].GetComponent<ItemSlot_isQuantity>().Quantity;
                        break;
                    }
                    else // 장비or오브는 같은 아이템이 있어도 다르게 인식해야함
                    {
                        isNoneSameItem = true;
                    }
                }
                else // 같은 아이템이 아니라면
                {
                    isNoneSameItem = true;
                }
            }
            else // 비어있으면
            {
                isEmptyAllSlot = true;
            }
        }

        if (isEmptyAllSlot || isNoneSameItem) // 슬롯이 전부 비어있거나 같은 이름의 아이템이 없다면
        {
            for (int i = 0; i < mySlots.Length; i++) // 비어있는 슬롯중에 가장 첫 슬롯에 넣는다.
            {
                if (mySlots[i].myItem == null)
                {
                    mySlots[i].Put_NewItem(item);
                    break;
                }
                else
                {
                    Debug.Log("인벤토리가 가득 찼습니다.");
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
                saveData.ItemType.Add((int)myType); // 아이템타입 저장
                saveData.ItemSlot.Add(i); // 슬롯번호 저장
                saveData.ItemID.Add(mySlots[i].myItem.myData.ID); // ID저장
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