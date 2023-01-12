using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

// ���콺 ������, �ڵ鷯
public class Icon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public Item.Type myType;
    public Item_Data Item_Data;

    protected Vector2 dragOffset = Vector2.zero;
    protected Vector2 size = Vector2.zero;

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
