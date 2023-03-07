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
        else // ��� Ÿ���� �������� �ƴ϶��
        {
            for (int i = 0; i < myTabs.Length; i++) // Ÿ�Կ� �´� ������ �ִ´�.
            {
                if (myTabs[i].myType == idata.ItemType)
                {
                    myTabs[i].Put_Item(item);
                    break;
                }
            }
        }
        Dont_Destroy_Data.Inst.ItemAcuisition_Message.Get_Item(item); //�޽��� ǥ��
    }
}
