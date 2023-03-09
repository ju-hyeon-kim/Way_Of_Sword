using UnityEngine;
using UnityEngine.EventSystems;

public class Item_Slot : MonoBehaviour, IDropHandler
{
    [Header("-----Item_Slot-----")]
    public ItemType SlotType;
    public int Quantity = 0;
    public bool isEmpty = true;

    public Item_2D myItem;
    protected Item_Slot BeforeSlot_ofItem;

    public void OnDrop(PointerEventData eventData)
    {
        Item_2D BeforeItem = myItem;
        myItem = eventData.pointerDrag.GetComponent<Item_2D>();

        if(!myItem.isItem_ofStore)
        {
            //�������� �������� ������ �˷��ִ� �ڵ�
            myItem.GetComponent<Item_2D>().isSlot = true;
            BeforeSlot_ofItem = myItem.Before_Slot;

            if (myItem.myData.ItemType == SlotType) //����Ÿ�԰� �������� Ÿ���� ���ٸ�
            {
                if (isEmpty) // ������ ����ִٸ�
                {
                    //�������� �޴´�.
                    myItem.transform.SetParent(transform); // �������� �������� �θ� = this ����
                    myItem.transform.SetAsFirstSibling();
                    myItem.transform.localPosition = Vector3.zero; // �������� �������� ������ �������� ����� ����
                    myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // ������ ���Կ� �°� ����
                    OnDrop_ofChild(eventData);
                    BeforeSlot_ofItem.isNone_Item(); // ���� ���Կ��� �������� ��������� �˷���
                    isEmpty = false;
                }
                else // ���Կ� �̹� �������� ��� �ִٸ�
                {
                    Slot_is_not_empty(BeforeItem, myItem);
                }
            }
            else
            {
                //�������� ���� �ʴ´�. -> ���� �ִ� �������� �ǵ��ư�
                myItem.transform.SetParent(this.BeforeSlot_ofItem.transform);
                myItem.transform.localPosition = Vector3.zero;
            }
        }
    }

    public virtual bool isSame_EquipnemtType() { return true; }

    public virtual void OnDrop_ofChild(PointerEventData eventData) { }

    public virtual void isNone_Item() { }

    public virtual void Slot_is_not_empty(Item_2D beforeItem, Item_2D newItem) { }
}
