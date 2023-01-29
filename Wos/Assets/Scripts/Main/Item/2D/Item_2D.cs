using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_2D : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler,IPointerMoveHandler, // 포인터 핸들러
    IBeginDragHandler, IDragHandler, IEndDragHandler // 드래그 핸들러
{
    public Item_Data myData;

    public Transform Canvas;
    public Transform Before_Parents; // 전에 있던 부모 오브젝트
    public int Before_ChildNum = 0; // 전에 있던 부모의 몇번째 자식이었는지 저장
    public bool isSlot = false; // 아이템이 슬롯위에 있는 알려주는 변수 -> 빈 화면에 아이템이 떨궈졌을 경우

    protected Vector2 dragOffset = Vector2.zero;
    protected Vector2 size = Vector2.zero;

    public Item_Types.ItemType myType;

    private void Start()
    {
        myType_Set();
    }

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

    public void OnBeginDrag(PointerEventData eventData) // 아이템을 들어올림
    {
        isSlot = false; // 슬롯이 정해질 때까지 false로 초기화

        //부모오브젝트 저장(슬롯에게 거부당할 경우를 위해)
        Before_Parents = transform.parent;
        Before_ChildNum = transform.GetSiblingIndex();

        //들어올린 오브젝트는 최상위 오브젝트(root = Canvus)의 가장 마지막 자식이 됨
        transform.SetParent(Canvas);

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

        // 아이템을 내려놓았을 때 받아줄 슬롯이 없다면 다시 돌아옴
        if (isSlot == false)
        {
            transform.SetParent(Before_Parents);
            transform.SetSiblingIndex(Before_ChildNum);
            transform.localPosition = Vector3.zero;
        }
    }

    public virtual void myType_Set()
    {
        //자식 스크립트 나의 타입을 정해줌
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
