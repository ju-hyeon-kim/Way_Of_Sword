using UnityEngine;

public class Inventory_Window : Window
{
    public Inventory_Tab[] myTabs;
    public Manager_Gold Manager_Gold;

    private void Start() // 테스트,마석15개 넣기
    {
        Debug.Log("스타트");
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
        else // 골드 타입의 아이템이 아니라면
        {
            for (int i = 0; i < myTabs.Length; i++) // 타입에 맞는 탭으로 넣는다.
            {
                if (myTabs[i].myType == idata.ItemType)
                {
                    for(int Q = 0; Q < Quantity; Q++) // 수량에 맞게 반복
                    {
                        myTabs[i].Put_Item(item);
                    }
                    Dont_Destroy_Data.Inst.ItemAcuisition_Message.Get_Item(item, Quantity); //메시지 표시
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
