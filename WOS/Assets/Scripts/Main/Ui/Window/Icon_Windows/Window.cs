using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Window : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 dragOffset = Vector2.zero;
    public void OnBeginDrag(PointerEventData eventData) //잡아서 들어올림
    {
        //들어올린 오브젝트는 가장 마지막 자식이 됨
        transform.SetAsLastSibling();

        GetComponent<Image>().raycastTarget = false;
        dragOffset = (Vector2)transform.position - eventData.position; //마우스 포지션 = 잡은 지점
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + dragOffset; //옮기기
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }
}
