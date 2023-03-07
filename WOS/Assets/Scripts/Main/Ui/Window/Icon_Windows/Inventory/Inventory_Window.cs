public class Inventory_Window : Window
{
    public Inventory_Tab[] myTabs;
    public Manager_Gold Manager_Gold;

    public void Put_Item(Item_2D item)
    {
        Item_Data idata = item.myData;
        if (idata.ItemType == ItemType.Gold)
        {
            Manager_Gold.PlusGold(idata.Price);
        }
        else // 골드 타입의 아이템이 아니라면
        {
            for (int i = 0; i < myTabs.Length; i++) // 타입에 맞는 탭으로 넣는다.
            {
                if (myTabs[i].myType == idata.ItemType)
                {
                    myTabs[i].Put_Item(item);
                    break;
                }
            }
        }
        Dont_Destroy_Data.Inst.ItemAcuisition_Message.Get_Item(item); //메시지 표시
    }
}
