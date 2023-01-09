using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

// ���콺 ������, �ڵ鷯
public class Icon_2D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        // Data Window���� Data�� ����
        GiveData_DW();

        //������ ����â Ȱ��ȭ
        Show_DataWindow();

        /*ItemData_Window.Inst.gameObject.SetActive(true);
        size = ItemData_Window.Inst.GetComponent<RectTransform>().sizeDelta;
        dragOffset = new Vector2(size.x * 0.5f + 0.2f, size.y * 0.5f + 0.2f);*/
    }

    public void OnPointerMove(PointerEventData eventData) // ���콺 �������� ������ �ȿ� ������
    {
        //ItemData_Window.Inst.transform.position = eventData.position + dragOffset;
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        //������ ����â ��Ȱ��ȭ
        //ItemData_Window.Inst.gameObject.SetActive(false);
    }

    public virtual void GiveData_DW()
    {

    }

    public virtual void Show_DataWindow()
    {

    }
}
