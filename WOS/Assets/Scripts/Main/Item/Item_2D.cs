using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_2D : ItemDrag_Area, 
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 dragOffset = Vector2.zero;
    public void OnPointerEnter(PointerEventData eventData) // 마우스 포지션이 아이콘 안으로 들어왔을때
    {
        //아이템 정보창 활성화
    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포지션이 아이콘 밖으로 빠져나갈 때
    {
        //아이템 정보창 비활성화
    }

    public void OnPointerDown(PointerEventData eventData) // 마우스 버튼을 눌렀을 때
    {

    }

    public void OnPointerUp(PointerEventData eventData) // 마우스 버튼을 뗐을 때
    {

    }

    public void OnBeginDrag(PointerEventData eventData) // 아이템을 들어올림
    {
        //들어올린 오브젝트는 캔버스의 가장 마지막 자식이 됨
        transform.SetParent(Drag_Area());

        GetComponent<Image>().raycastTarget = false;
        dragOffset = (Vector2)transform.position - eventData.position; // 마우스 포지션 = 잡은 지점
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + dragOffset; // 옮기기
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }
}
