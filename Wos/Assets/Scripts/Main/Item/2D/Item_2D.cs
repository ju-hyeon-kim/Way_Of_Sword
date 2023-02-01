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
    ItemData_Window myData_Window;

    public Transform Before_Parents; // ���� �ִ� �θ� ������Ʈ
    public int Before_ChildNum = 0; // ���� �ִ� �θ��� ���° �ڽ��̾����� ����
    public bool isSlot = false; // �������� �������� �ִ� �˷��ִ� ���� -> �� ȭ�鿡 �������� �������� ���

    protected Vector2 dragOffset = Vector2.zero;
    protected Vector2 size = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_Windows.Show_DataWindow(this);
    }

    public void OnPointerMove(PointerEventData eventData) // ���콺 �������� ������ �ȿ� ������
    {
        myData_Window.Updating_Position(eventData);
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        myData_Window.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData) // �������� ���ø�
    {
        isSlot = false; // ������ ������ ������ false�� �ʱ�ȭ

        //�θ������Ʈ ����(���Կ��� �źδ��� ��츦 ����)
        Before_Parents = transform.parent;
        Before_ChildNum = transform.GetSiblingIndex();

        //���ø� ������Ʈ�� Canvas�� ���� ������ �ڽ��� ��
        transform.SetParent(Dont_Destroy_Data.Inst.Canvas);

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
}
