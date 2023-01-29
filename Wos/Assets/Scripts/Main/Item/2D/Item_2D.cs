using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_2D : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler,IPointerMoveHandler, // ������ �ڵ鷯
    IBeginDragHandler, IDragHandler, IEndDragHandler // �巡�� �ڵ鷯
{
    public Item_Data myData;

    public Transform Canvas;
    public Transform Before_Parents; // ���� �ִ� �θ� ������Ʈ
    public int Before_ChildNum = 0; // ���� �ִ� �θ��� ���° �ڽ��̾����� ����
    public bool isSlot = false; // �������� �������� �ִ� �˷��ִ� ���� -> �� ȭ�鿡 �������� �������� ���

    protected Vector2 dragOffset = Vector2.zero;
    protected Vector2 size = Vector2.zero;

    public Item_Types.ItemType myType;

    private void Start()
    {
        myType_Set();
    }

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        // Data Window���� Data�� ����
        GiveData_DW();

        // Data Window Ȱ��ȭ
        Show_DataWindow();
    }

    public void OnPointerMove(PointerEventData eventData) // ���콺 �������� ������ �ȿ� ������
    {
        Updating_DataWindow(eventData); // ����Ÿ �������� �������� ���콺 �����ǿ� �°� ��� ������Ʈ����
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        //������ ����â ��Ȱ��ȭ
        unShow_DataWindow();
    }

    public void OnBeginDrag(PointerEventData eventData) // �������� ���ø�
    {
        isSlot = false; // ������ ������ ������ false�� �ʱ�ȭ

        //�θ������Ʈ ����(���Կ��� �źδ��� ��츦 ����)
        Before_Parents = transform.parent;
        Before_ChildNum = transform.GetSiblingIndex();

        //���ø� ������Ʈ�� �ֻ��� ������Ʈ(root = Canvus)�� ���� ������ �ڽ��� ��
        transform.SetParent(Canvas);

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

        // �������� ���������� �� �޾��� ������ ���ٸ� �ٽ� ���ƿ�
        if (isSlot == false)
        {
            transform.SetParent(Before_Parents);
            transform.SetSiblingIndex(Before_ChildNum);
            transform.localPosition = Vector3.zero;
        }
    }

    public virtual void myType_Set()
    {
        //�ڽ� ��ũ��Ʈ ���� Ÿ���� ������
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
