using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Window : MonoBehaviour
{
    public Inventory_Tab[] myTabs;
    public Manager_Player Manager_Player;

    public void Put_Item(Item_2D item)
    {
        Item_Data idata = item.myData;
        if(idata.ItemType == ItemType.Gold)
        {
            Manager_Player.PlusGold(idata.Price);
        }
        else
        {
            for(int i =0; i < myTabs.Length; i++) 
            {
                if(myTabs[i].myType == idata.ItemType)
                {
                    myTabs[i].Put_Item(item);
                    break;
                }
            }
        }
    }
}
