using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_2D : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, // ������ �ڵ鷯
    IBeginDragHandler, IDragHandler, IEndDragHandler // �巡�� �ڵ鷯
{
    [Header("-----Item_2D-----")]
    public Item_Data myData;
    public bool isItem_OnSlot = false; // �������� �������� �ִ� �˷��ִ� ���� -> �� ȭ�鿡 �������� �������� ���
    public bool canDrag = true; //�巡�׸� �Ҽ� �ִ���
    public bool canViewData = true; //����Ÿ�� ���� �ִ���
    [HideInInspector]
    public Item_Slot Before_Slot = null; // ���� �ִ� �θ� ������Ʈ

    protected ItemData_Window myData_Window;
    protected Vector2 dragOffset = Vector2.zero;
    protected Vector2 size = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        if(canViewData)
        {
            Reset_myDataWindow(); // myDataWindow �ʱ�ȭ (�ڽĿ� �°�)
            myData_Window.Data_Setting(this);
            myData_Window.gameObject.SetActive(true);
        }
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
        if(canDrag) // �������� �Ĵ� �������� �ƴϾ�� �巡�� ����
        {
            isItem_OnSlot = false; // ������ ������ ������ false�� �ʱ�ȭ

            //�θ������Ʈ ����(���Կ��� �źδ��� ��츦 ����)
            Before_Slot = transform.parent.GetComponent<Item_Slot>();
            Before_Slot.myItem = null;
            QuantityOnOff_ofBeforeSlot(false);

            //���ø� ������Ʈ�� Canvas�� ���� ������ �ڽ��� ��
            transform.SetParent(Dont_Destroy_Data.Inst.Canvas);

            GetComponent<Image>().raycastTarget = false;
            dragOffset = (Vector2)transform.position - eventData.position; // ���콺 ������ = ���� ����
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            transform.position = eventData.position + dragOffset; // �ű��
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            GetComponent<Image>().raycastTarget = true;

            // �������� ���������� �� �޾��� ������ ���ٸ� �ٽ� ���ƿ�
            if (isItem_OnSlot == false)
            {
                QuantityOnOff_ofBeforeSlot(true);
                transform.SetParent(Before_Slot.transform);
                transform.SetAsFirstSibling();
                transform.localPosition = Vector3.zero;
            }
        }
    }

    public virtual void Reset_myDataWindow() { }

    public virtual void QuantityOnOff_ofBeforeSlot(bool b) { }
}
