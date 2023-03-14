 using UnityEngine;
using UnityEngine.EventSystems;

public class Item_Slot : MonoBehaviour, IDropHandler
{
    //[Header("-----Item_Slot-----")]
    [HideInInspector]
    public Item_2D myItem;

    protected Item_Slot BeforeSlot_ofItem;

    public void OnDrop(PointerEventData eventData)
    {
        Item_2D NewItem = eventData.pointerDrag.GetComponent<Item_2D>();
        NewItem.isItem_inSlot = true;
        BeforeSlot_ofItem = NewItem.Before_Slot;

        if (!NewItem.isItem_inStore)
        {
            if (isSameType(NewItem)) //슬롯타입과 아이템의 타입이 같다면
            {
                if (myItem == null) // 슬롯이 비어있다면
                {
                    //아이템을 받는다.
                    myItem = NewItem;
                    myItem.transform.SetParent(transform); // 내려놓은 오브제의 부모 = this 슬롯
                    myItem.transform.SetAsFirstSibling();
                    myItem.transform.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
                    myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // 사이즈 슬롯에 맞게 설정
                    GetQuantity_fromBeforslot(BeforeSlot_ofItem);
                    OnDrop_ofChild();
                    BeforeSlot_ofItem.isNoneItem(); // 전의 슬롯에게 아이템이 사라졌음을 알려줌
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

    public void Put_NewItem(Item_2D item)
    {
        GameObject Obj = Instantiate(item.gameObject, transform) as GameObject;
        Obj.transform.SetAsFirstSibling(); // 첫번째 자식으로 변경
        myItem = Obj.GetComponent<Item_2D>();
        myItem.isItem_inStore = false;
        if(myItem.GetComponent<Item2D_isQuantity>() != null)
        {
            Put_NewQuantityItem();
        }
    }

    public string Get_myItemName()
    {
        return myItem.myData.Name;
    }

    public virtual void isNoneItem_ofChild() { }

    public virtual void Change_Item(Item_2D beforeItem, Item_2D newItem) { }

    public virtual bool isSameType(Item_2D NewItem2D) { return true; }

    public virtual void isEquipment() { }

    public virtual void GetQuantity_fromBeforslot(Item_Slot BeforeSlot) { }

    public virtual void Put_NewQuantityItem() { }

    public virtual void OnDrop_ofChild() { }
}
