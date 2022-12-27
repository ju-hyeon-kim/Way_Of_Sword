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
    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        //������ ����â Ȱ��ȭ
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        //������ ����â ��Ȱ��ȭ
    }

    public void OnPointerDown(PointerEventData eventData) // ���콺 ��ư�� ������ ��
    {

    }

    public void OnPointerUp(PointerEventData eventData) // ���콺 ��ư�� ���� ��
    {

    }

    public void OnBeginDrag(PointerEventData eventData) // �������� ���ø�
    {
        //���ø� ������Ʈ�� ĵ������ ���� ������ �ڽ��� ��
        transform.SetParent(Drag_Area());

        GetComponent<Image>().raycastTarget = false;
        dragOffset = (Vector2)transform.position - eventData.position; // ���콺 ������ = ���� ����
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + dragOffset; // �ű��
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }
}
