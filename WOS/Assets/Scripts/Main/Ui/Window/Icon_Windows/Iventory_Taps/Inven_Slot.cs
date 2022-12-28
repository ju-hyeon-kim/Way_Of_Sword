using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inven_Slot : Item_Slot
{
    public override void DropEvent(PointerEventData eventData)
    {
        // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
        eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        // 오브제는 슬롯의 2번째 자식으로 설정
        eventData.pointerDrag.transform.SetAsFirstSibling(); 
    }
}
