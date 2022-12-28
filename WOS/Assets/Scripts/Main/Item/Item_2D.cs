using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_2D : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, // 포인터 핸들러
    IBeginDragHandler, IDragHandler, IEndDragHandler // 드래그 핸들러
{
    public Transform Before_Parents; // 전에 있던 부모 오브젝트
    public int Before_ChildNum = 0; // 전에 있던 부모의 몇번째 자식이었는지 저장
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
        //부모오브젝트 저장(슬롯에게 거부당할 경우를 위해)
        Before_Parents = transform.parent;
        Before_ChildNum = transform.GetSiblingIndex();

        //들어올린 오브젝트는 최상위 오브젝트(root = Canvus)의 가장 마지막 자식이 됨
        transform.SetParent(transform.root);

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
