using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

// 마우스 포인터, 핸들러
public class Icon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public Item.Type myType;
    public Item_Data Item_Data;

    protected Vector2 dragOffset = Vector2.zero;
    protected Vector2 size = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData) // 마우스 포지션이 아이콘 안으로 들어왔을때
    {
        // Data Window에게 Data를 전달
        GiveData_DW();

        // Data Window 활성화
        Show_DataWindow();
    }

    public void OnPointerMove(PointerEventData eventData) // 마우스 포지션이 아이콘 안에 있을때
    {
        Updating_DataWindow(eventData); // 데이타 윈도우의 포지션을 마우스 포지션에 맞게 계속 업데이트해줌
    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포지션이 아이콘 밖으로 빠져나갈 때
    {
        //아이템 정보창 비활성화
        unShow_DataWindow();
    }

    public virtual void GiveData_DW()
    {
    }

    public virtual void Show_DataWindow()
    {
    }

    public virtual void Updating_DataWindow(PointerEventData eventData)
    {
    }

    public virtual void unShow_DataWindow()
    {
    }
}
