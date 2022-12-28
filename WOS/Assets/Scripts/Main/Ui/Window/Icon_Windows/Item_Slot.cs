using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SlotType
{
    PlayerEquipment, InvenEquipment
}

public class Item_Slot : MonoBehaviour, IDropHandler
{
    public SlotType myType = default(SlotType); // 인스펙터에서 정해줌

    public virtual void OnDrop(PointerEventData eventData)
    {
        switch(myType) 
        {
            case SlotType.InvenEquipment: // 인벤토리창의 장비 창일 경우
                // 아이템이 떨궈졌을 때 장비 아이템이 아니면 받을 수 없다
                if (eventData.pointerDrag.transform.GetComponent<Item_Icon>().myType == Item.Type.Equipment)
                {
                    eventData.pointerDrag.transform.SetParent(transform); // 내려놓은 오브제의 부모 = 슬롯
                    eventData.pointerDrag.transform.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
                }
                // 아이템이 떨궈졌을 때 아이콘의 크기가 슬롯에 맞게 줄어듬
                eventData.pointerDrag.transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
                break;
            case SlotType.PlayerEquipment: // 플레이어창의 장비 창일 경우
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
