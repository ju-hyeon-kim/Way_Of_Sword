using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Window : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 dragOffset = Vector2.zero;
    public void OnBeginDrag(PointerEventData eventData) //��Ƽ� ���ø�
    {
        //���ø� ������Ʈ�� ���� ������ �ڽ��� ��
        transform.SetAsLastSibling();

        GetComponent<Image>().raycastTarget = false;
        dragOffset = (Vector2)transform.position - eventData.position; //���콺 ������ = ���� ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + dragOffset; //�ű��
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }
}
