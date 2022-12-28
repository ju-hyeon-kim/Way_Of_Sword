using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inven_Slot : MonoBehaviour, IDropHandler
{
    ItemSlot_Type itemslot_type = ItemSlot_Type.Inven;
    public InvenSlot_Type invenslot_type = default(InvenSlot_Type); // 인스펙터에서 정해줌

    public void OnDrop(PointerEventData eventData)
    {
        switch (invenslot_type)
        {
            case InvenSlot_Type.Equipment: // 인벤창의 장비슬롯일 경우
                if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == Item.Type.Equipment)
                {
                    eventData.pointerDrag.transform.SetParent(transform); // 내려놓은 오브제의 부모 = 슬롯
                    eventData.pointerDrag.transform.SetSiblingIndex(1); // 오브제는 슬롯의 2번째 자식으로 설정
                    eventData.pointerDrag.transform.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
                }
                // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
                eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
                break;
        }
    }
}
