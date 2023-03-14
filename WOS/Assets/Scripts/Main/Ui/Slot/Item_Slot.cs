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
            if (isSameType(NewItem)) //����Ÿ�԰� �������� Ÿ���� ���ٸ�
            {
                if (myItem == null) // ������ ����ִٸ�
                {
                    //�������� �޴´�.
                    myItem = NewItem;
                    myItem.transform.SetParent(transform); // �������� �������� �θ� = this ����
                    myItem.transform.SetAsFirstSibling();
                    myItem.transform.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
                    myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // ������ ���Կ� �°� ����
                    GetQuantity_fromBeforslot(BeforeSlot_ofItem);
                    OnDrop_ofChild();
                    BeforeSlot_ofItem.isNoneItem(); // ���� ���Կ��� �������� ��������� �˷���
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

    public void Put_NewItem(Item_2D item)
    {
        GameObject Obj = Instantiate(item.gameObject, transform) as GameObject;
        Obj.transform.SetAsFirstSibling(); // ù��° �ڽ����� ����
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
