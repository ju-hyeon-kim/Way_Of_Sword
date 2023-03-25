 using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.PostProcessing.SubpixelMorphologicalAntialiasing;

public class Item_Slot : MonoBehaviour, IDropHandler
{
    [Header("-----Item_Slot-----")]
    //[HideInInspector]
    public Item_2D myItem;

    protected Item_Slot BeforeSlot_ofItem;

    public void OnDrop(PointerEventData eventData)
    {
        Item_2D NewItem = eventData.pointerDrag.GetComponent<Item_2D>();

        if(NewItem.canDrag)
        {
            NewItem.isItem_OnSlot = true;
            if (isSameType(NewItem)) //슬롯타입과 아이템의 타입이 같다면
            {
                if (myItem == null) // 슬롯이 비어있다면
                {
                    //아이템을 받는다.
                    Receive_Item(NewItem);
                    GetQuantity_fromBeforslot(BeforeSlot_ofItem);
                    OnDrop_ofChild();
                }
                else // 슬롯에 이미 아이템이 들어 있다면
                {
                    Item_2D BeforeItem = myItem;
                    Change_Item(BeforeItem, NewItem);
                }
            }
            else
            {
                //아이템을 받지 않는다. -> 전에 있던 슬롯으로 되돌아감
                myItem.transform.SetParent(this.BeforeSlot_ofItem.transform);
                myItem.transform.localPosition = Vector3.zero;
            }
        }
        isEquipment(); // 장비라면 스탯창 초기화
    }

    public void isNoneItem()
    {
        myItem = null;
        isNoneItem_ofChild();
    }

    public void Put_NewItem(Item_2D item, int quantity = 1)
    {
        GameObject obj = Instantiate(item.gameObject);
        if (obj.GetComponent<Item2D_isQuantity>() != null)
        {
            ItemSlot_isQuantity QuantitySlot = GetComponent<ItemSlot_isQuantity>();
            QuantitySlot.Quantity = quantity;
            QuantitySlot.QuantityArea.SetActive(true);
        }
        Receive_Item(obj.GetComponent<Item_2D>());
    }

    void Receive_Item(Item_2D item)
    {
        item.transform.SetParent(this.transform); // 부모를 this로 변경
        item.transform.SetAsFirstSibling(); // 첫번째 자식으로 이동
        item.transform.localPosition = Vector3.zero; // 위치 설정
        item.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // 사이즈 설정
        if (item.Before_Slot != null)
        {
            item.Before_Slot.isNoneItem();// 전에 있던 슬롯의 myItem은 null;
        }
        myItem = item;
        myItem.Before_Slot = this;
    }

    public virtual void isNoneItem_ofChild() { }

    public virtual void Change_Item(Item_2D beforeItem, Item_2D newItem) { }

    public virtual bool isSameType(Item_2D NewItem2D) { return true; }

    public virtual void isEquipment() { }

    public virtual void GetQuantity_fromBeforslot(Item_Slot BeforeSlot) { }

    public virtual void OnDrop_ofChild() { }
}
