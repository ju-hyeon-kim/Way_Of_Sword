using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Inventory_Window : Window
{
    public Inventory_Tab[] myTabs;
    public Manager_Gold Manager_Gold;

    private void Start() // �׽�Ʈ�ڵ�(�����־�α�)
    {
        GameObject obj = Instantiate(Dont_Destroy_Data.Inst.Manager_Item.ItemList[13]);
        PutItem(obj.GetComponent<Item_2D>(), 999);
    }

    public void PutItem(Item_2D item, int Quantity = 1)
    {
        item.isItem_OnSlot = true;
        item.canDrag = true;
        item.canViewData = true;

        Item_Data idata = item.myData;
        if (idata.ItemType == ItemType.Gold)
        {
            Manager_Gold.NowGold += idata.SellPrice;
        }
        else // ��� Ÿ���� �������� �ƴ϶��
        {
            for (int i = 0; i < myTabs.Length; i++) // Ÿ�Կ� �´� ������ �ִ´�.
            {
                if (myTabs[i].myType == idata.ItemType)
                {
                    for(int Q = 0; Q < Quantity; Q++) // ������ �°� �ݺ�
                    {
                        myTabs[i].Put_Item(item);
                    }
                    Dont_Destroy_Data.Inst.ItemAcuisition_Message.Get_Item(item, Quantity); //�޽��� ǥ��
                    break;
                }
            }
        }
    }

    public void PutItem_AfterCreate(Item_2D item, int Quantity = 1)
    {
        GameObject obj = Instantiate(item.gameObject);
        Debug.Log(obj.transform.parent);
        PutItem(obj.GetComponent<Item_2D>(), Quantity);
    }

    public int Get_HaveAmount_ofMagicStone()
    {
        return myTabs[3].GetComponent<Ingredient_Tab>().Get_HaveAmount_MagicStone();
    }

    public void Pay_MagicStone(int quantitiy) // ������ �����ϴ� = ��ȭ
    {
        myTabs[3].GetComponent<Ingredient_Tab>().Pay_Mstone(quantitiy);
    }

    public void Save_ItemData(SaveData savedata)
    {
        for(int i = 0; i < myTabs.Length; i++)
        {
            myTabs[i].Save_ItemData(savedata);
        }
    }

    public void Load_ItemData(SaveData savedata)
    {
        RemoveAll_Item();
        for (int i = 0; i < savedata.ItemType.Count; i++)
        {
            myTabs[savedata.ItemType[i]].Load_ItemData(savedata, i);
        }
    }

    void RemoveAll_Item()
    {
        for (int i = 0; i < myTabs.Length; i++)
        {
            myTabs[i].RemoveAll_Item();
        }
    }
}
