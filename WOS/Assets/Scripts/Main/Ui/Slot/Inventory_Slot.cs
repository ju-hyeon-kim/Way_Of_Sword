using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory_Slot : Item_Slot
{
    //[Header("-----Inventory_Slot-----")]
    //public TMP_Text Quantity_Text = null;

    public override void OnDrop_ofChild(PointerEventData eventData)
    {
        myItem = eventData.pointerDrag.GetComponent<Item_2D>();

        // 수량 가져오기
        /*if (myItem.myData.ItemType == ItemType.Expendables || myItem.myData.ItemType == ItemType.Ingredient)
        {
            Quantity = myItem.Before_Slot.GetComponent<Item_Slot>().Quantity;
            Quantity_Text.text = Quantity.ToString();
            Quantity_Text.transform.parent.gameObject.SetActive(true);
        }*/
    }

    public void Put_NewItem(Item_2D item)
    {
        myItem = item;

        GameObject Obj = Instantiate(item.gameObject, transform) as GameObject;
        Obj.transform.SetAsFirstSibling(); // 첫번째 자식으로 변경

        /*if (myItem.myData.ItemType == ItemType.Expendables || myItem.myData.ItemType == ItemType.Ingredient) // 소모품과 재료는 수량을 표시함
        {
            Quantity++;
            Quantity_Text.text = $"{Quantity}";
            Quantity_Text.transform.parent.gameObject.SetActive(true);
        }*/

        myItem = Obj.GetComponent<Item_2D>();
        isEmpty = false;
    }

    public virtual void Put_SameItem()
    {
        /*if (myItem.myData.ItemType == ItemType.Expendables || myItem.myData.ItemType == ItemType.Ingredient)
        {
            Quantity++;
            Quantity_Text.text = $"{Quantity}";
        }*/
    }

    public string Get_myItemName()
    {
        return myItem.myData.Name;
    }

    public override void isNone_Item() // 아이템이 없을 때
    {
        /*if (myItem.myData.ItemType == ItemType.Expendables || myItem.myData.ItemType == ItemType.Ingredient)
        {
            Quantity = 0;
            Quantity_Text.transform.parent.gameObject.SetActive(false);
        }*/
    }
}
