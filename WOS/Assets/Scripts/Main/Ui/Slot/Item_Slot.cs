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
            if (isSameType(NewItem)) //����Ÿ�԰� �������� Ÿ���� ���ٸ�
            {
                if (myItem == null) // ������ ����ִٸ�
                {
                    //�������� �޴´�.
                    Receive_Item(NewItem);
                    GetQuantity_fromBeforslot(BeforeSlot_ofItem);
                    OnDrop_ofChild();
                }
                else // ���Կ� �̹� �������� ��� �ִٸ�
                {
                    Item_2D BeforeItem = myItem;
                    Change_Item(BeforeItem, NewItem);
                }
            }
            else
            {
                //�������� ���� �ʴ´�. -> ���� �ִ� �������� �ǵ��ư�
                myItem.transform.SetParent(this.BeforeSlot_ofItem.transform);
                myItem.transform.localPosition = Vector3.zero;
            }
        }
        isEquipment(); // ����� ����â �ʱ�ȭ
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
        item.transform.SetParent(this.transform); // �θ� this�� ����
        item.transform.SetAsFirstSibling(); // ù��° �ڽ����� �̵�
        item.transform.localPosition = Vector3.zero; // ��ġ ����
        item.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // ������ ����
        if (item.Before_Slot != null)
        {
            item.Before_Slot.isNoneItem();// ���� �ִ� ������ myItem�� null;
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
