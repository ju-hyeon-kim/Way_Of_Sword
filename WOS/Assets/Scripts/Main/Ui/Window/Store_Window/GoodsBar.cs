using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoodsBar : MonoBehaviour
{
    public Transform ItemSlot;
    public TMP_Text ItemName;
    public TMP_Text ItemPrice;
    public int ItemID_forSell = 0;

    Item_2D myItem = null;

    public void ReadytoSell()
    {
        GameObject Item = Instantiate(Dont_Destroy_Data.Inst.Manager_Item.ItemList[ItemID_forSell], ItemSlot);
        Item.transform.SetAsFirstSibling();
        myItem = Item.GetComponent<Item_2D>();

        ItemName.text = myItem.myData.Name;
        ItemPrice.text = $"가격: {myItem.myData.Price}G";

    }

    public void BuyButton()
    {
        Debug.Log("아이템을 삽니다.");
    }
}
