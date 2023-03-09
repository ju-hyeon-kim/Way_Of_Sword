using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GoodsBar : MonoBehaviour
{
    public Transform ItemSlot;
    public TMP_Text ItemName;
    public TMP_Text QuantityText;
    public TMP_Text ItemPrice;
    public int ItemID_forSell = 0;

    int Quantity = 1;
    Item_2D myItem = null;

    public void ReadytoSell()
    {
        GameObject Item = Instantiate(Dont_Destroy_Data.Inst.Manager_Item.ItemList[ItemID_forSell], ItemSlot);
        Item.transform.SetAsFirstSibling();
        myItem = Item.GetComponent<Item_2D>();
        myItem.isItem_ofStore = true;
        ItemName.text = myItem.myData.Name;
        ItemPrice.text = $"가격: {myItem.myData.Price}G";
    }

    public void BuyButton()
    {
        //Question_Window 실행
        Question_Window QW = Dont_Destroy_Data.Inst.Question_Window;
        string s = $"{myItem.myData.Name}를(을) 구매하시겠습니까?\n필요골드: {myItem.myData.Price * Quantity}G";
        QW.WindowSetting(s, () => QW_YButton());
        QW.gameObject.SetActive(true);
    }

    void QW_YButton()
    {
        int gold = Dont_Destroy_Data.Inst.Manager_Gold.NowGold;
        if(myItem.myData.Price > gold) // 소지금이 부족할 때
        {
            Dont_Destroy_Data.Inst.GoldLack_Message.SetActive(true);
        }
        else // 아이템을 살 돈이 있다면
        {
            //계산
            Dont_Destroy_Data.Inst.Manager_Gold.NowGold -= myItem.myData.Price;
            //수량에 맞게 반복
            for(int i = 0; i < Quantity; i++)
            {
                Dont_Destroy_Data.Inst.Inventory_Window.Put_Item(myItem);
            }
        }
    }

    public void MinusButton_ofQuantity()
    {
        if(Quantity > 1) --Quantity;
        QuantityText.text = Quantity.ToString();
    }

    public void PlusButton_ofQuantity()
    {
        if(Quantity < 99) ++Quantity;
        QuantityText.text = Quantity.ToString();
    }
}
