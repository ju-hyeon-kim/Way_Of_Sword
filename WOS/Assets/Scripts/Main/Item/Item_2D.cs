using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_2D : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, // ������ �ڵ鷯
    IBeginDragHandler, IDragHandler, IEndDragHandler // �巡�� �ڵ鷯
{
    public Transform Before_Parents; // ���� �ִ� �θ� ������Ʈ
    public int Before_ChildNum = 0; // ���� �ִ� �θ��� ���° �ڽ��̾����� ����
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
        //�θ������Ʈ ����(���Կ��� �źδ��� ��츦 ����)
        Before_Parents = transform.parent;
        Before_ChildNum = transform.GetSiblingIndex();

        //���ø� ������Ʈ�� �ֻ��� ������Ʈ(root = Canvus)�� ���� ������ �ڽ��� ��
        transform.SetParent(transform.root);

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
