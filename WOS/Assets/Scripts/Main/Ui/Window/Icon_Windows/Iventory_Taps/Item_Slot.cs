using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Item_Slot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Transform myItem = eventData.pointerDrag.transform;

        if (TypeDetect(eventData))
        {
            //아이템을 받는다.
            myItem.SetParent(transform); // 내려놓은 오브제의 부모 = 슬롯
            myItem.localPosition = Vector3.zero; // 오브제의 포지션은 슬롯을 기준으로 가운데로 설정
            DropEvent(eventData);
        }
        else
        {
            //아이템을 받지 않는다.
            myItem.SetParent(myItem.GetComponent<Item_2D>().Before_Parents);
            myItem.SetSiblingIndex(myItem.GetComponent<Item_2D>().Before_ChildNum);
            myItem.localPosition = Vector3.zero;
        }
    }

    public virtual void DropEvent(PointerEventData eventData)
    {
        //자식따라서 재정의
    }

    public virtual bool TypeDetect(PointerEventData eventData) //아이템 타입을 감지하여 슬롯에 받을지 말지를 검사한다.
    {
        //자식따라서 재정의
        return true;
    }
}
