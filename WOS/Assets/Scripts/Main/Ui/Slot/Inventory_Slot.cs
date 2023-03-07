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

        // ���� ��������
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
        Obj.transform.SetAsFirstSibling(); // ù��° �ڽ����� ����

        /*if (myItem.myData.ItemType == ItemType.Expendables || myItem.myData.ItemType == ItemType.Ingredient) // �Ҹ�ǰ�� ���� ������ ǥ����
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

    public override void isNone_Item() // �������� ���� ��
    {
        /*if (myItem.myData.ItemType == ItemType.Expendables || myItem.myData.ItemType == ItemType.Ingredient)
        {
            Quantity = 0;
            Quantity_Text.transform.parent.gameObject.SetActive(false);
        }*/
    }
}
