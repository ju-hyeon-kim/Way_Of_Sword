using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_Icon : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler,IPointerMoveHandler, IPointerDownHandler, IPointerUpHandler, // ������ �ڵ鷯
    IBeginDragHandler, IDragHandler, IEndDragHandler // �巡�� �ڵ鷯
{
    public Transform Before_Parents; // ���� �ִ� �θ� ������Ʈ
    public int Before_ChildNum = 0; // ���� �ִ� �θ��� ���° �ڽ��̾����� ����
    public bool isSlot = false; // �������� �������� �ִ� �˷��ִ� ���� -> �� ȭ�鿡 �������� �������� ���

    Vector2 dragOffset = Vector2.zero;
    Vector2 size = Vector2.zero;

    public Item.Type myType;

    private void Start()
    {
        myType_Set();
    }

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        // �������� ������ ������ ����â�� ����
        GiveData();

        //������ ����â Ȱ��ȭ
        ItemData_Window.Inst.gameObject.SetActive(true);
        size = ItemData_Window.Inst.GetComponent<RectTransform>().sizeDelta;
        dragOffset = new Vector2(size.x * 0.5f + 0.2f, size.y * 0.5f + 0.2f);
    }

    public void OnPointerMove(PointerEventData eventData) // ���콺 �������� ������ �ȿ� ������
    {
        ItemData_Window.Inst.transform.position = eventData.position + dragOffset;
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        //������ ����â ��Ȱ��ȭ
        ItemData_Window.Inst.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData) // ���콺 ��ư�� ������ ��
    {

    }

    public void OnPointerUp(PointerEventData eventData) // ���콺 ��ư�� ���� ��
    {

    }

    public void OnBeginDrag(PointerEventData eventData) // �������� ���ø�
    {
        isSlot = false; // ������ ������ ������ false�� �ʱ�ȭ

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

        // �������� ���������� �� �޾��� ������ ���ٸ� �ٽ� ���ƿ�
        if (isSlot == false)
        {
            transform.SetParent(Before_Parents);
            transform.SetSiblingIndex(Before_ChildNum);
            transform.localPosition = Vector3.zero;
        }
    }

    public virtual void GiveData()
    {
        //�ڽ� ��ũ��Ʈ���� ������
    }

    public virtual void myType_Set()
    {
        //�ڽ� ��ũ��Ʈ ���� Ÿ���� ������
    }
}
