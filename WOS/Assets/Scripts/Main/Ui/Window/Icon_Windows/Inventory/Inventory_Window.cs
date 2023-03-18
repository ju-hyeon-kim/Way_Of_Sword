using UnityEngine;

public class Inventory_Window : Window
{
    public Inventory_Tab[] myTabs;
    public Manager_Gold Manager_Gold;

    private void Start() // �׽�Ʈ,����15�� �ֱ�
    {
        Debug.Log("��ŸƮ");
        Put_Item(Dont_Destroy_Data.Inst.Manager_Item.ItemList[13].GetComponent<Item_2D>(), 15);
    }

    public void Put_Item(Item_2D item, int Quantity = 1)
    {
        item.isItem_inSlot = true;
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

    public int Get_HaveAmount_ofMagicStone()
    {
        return myTabs[3].GetComponent<Ingredient_Tab>().Get_HaveAmount_MagicStone();
    }
}
