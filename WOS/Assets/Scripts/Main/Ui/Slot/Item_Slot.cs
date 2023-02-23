using UnityEngine;
using UnityEngine.EventSystems;

public class Item_Slot : MonoBehaviour, IDropHandler
{
    [Header("-----Item_Slot-----")]
    public ItemType SlotType;
    public int Quantity = 0;
    public bool isEmpty = true;

    protected Item_2D myItem;
    protected Item_Slot BeforeSlot_ofItem;

    public void OnDrop(PointerEventData eventData)
    {

        myItem = eventData.pointerDrag.GetComponent<Item_2D>();
        //아이템이 슬롯위에 있음을 알려주는 코드
        myItem.GetComponent<Item_2D>().isSlot = true;
        BeforeSlot_ofItem = myItem.Before_Slot;

        if (myItem.myData.ItemType == SlotType) //아이템 타입을 감지하여 슬롯에 받을지 말지를 검사한다.
        {
            if (isSame_EquipnemtType())
            {
                //아이템을 받는다.
                myItem.transform.SetParent(transform); // 내려놓은 오브제의 부모 = this 슬롯
                myItem.transform.SetAsFirstSibling();
                myItem.transform.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
                myItem.GetComponent<RectTransform>().sizeDelta = Vector2.zero; // 사이즈 슬롯에 맞게 설정
                OnDrop_ofChild(eventData);
                BeforeSlot_ofItem.isNone_Item(); // 전의 슬롯에게 아이템이 사라졌음을 알려줌
                isEmpty = false;
            }
            else
            {
                //아이템을 받지 않는다. -> 전에 있던 슬롯으로 되돌아감
                myItem.transform.SetParent(this.BeforeSlot_ofItem.transform);
                myItem.transform.localPosition = Vector3.zero;
            }
        }
        else
        {
            //아이템을 받지 않는다. -> 전에 있던 슬롯으로 되돌아감
            myItem.transform.SetParent(this.BeforeSlot_ofItem.transform);
            myItem.transform.localPosition = Vector3.zero;
        }
    }
    public virtual bool isSame_EquipnemtType() { return true; }

    public virtual void OnDrop_ofChild(PointerEventData eventData) { }

    public virtual void isNone_Item() { }
}
