using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_2D : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, // 포인터 핸들러
    IBeginDragHandler, IDragHandler, IEndDragHandler // 드래그 핸들러
{
    [Header("-----Item_2D-----")]
    public Item_Data myData;
    public bool isItem_OnSlot = false; // 아이템이 슬롯위에 있는 알려주는 변수 -> 빈 화면에 아이템이 떨궈졌을 경우
    public bool canDrag = true; //드래그를 할수 있는지
    public bool canViewData = true; //데이타를 볼수 있는지
    [HideInInspector]
    public Item_Slot Before_Slot = null; // 전에 있던 부모 오브젝트

    protected ItemData_Window myData_Window;
    protected Vector2 dragOffset = Vector2.zero;
    protected Vector2 size = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData) // 마우스 포지션이 아이콘 안으로 들어왔을때
    {
        if(canViewData)
        {
            Reset_myDataWindow(); // myDataWindow 초기화 (자식에 맞게)
            myData_Window.Data_Setting(this);
            myData_Window.gameObject.SetActive(true);
        }
    }

    public void OnPointerMove(PointerEventData eventData) // 마우스 포지션이 아이콘 안에 있을때
    {
        myData_Window.Updating_Position(eventData);
    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포지션이 아이콘 밖으로 빠져나갈 때
    {
        myData_Window.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData) // 아이템을 들어올림
    {
        if(canDrag) // 상점에서 파는 아이템이 아니어야 드래그 가능
        {
            isItem_OnSlot = false; // 슬롯이 정해질 때까지 false로 초기화

            //부모오브젝트 저장(슬롯에게 거부당할 경우를 위해)
            Before_Slot = transform.parent.GetComponent<Item_Slot>();
            Before_Slot.myItem = null;
            QuantityOnOff_ofBeforeSlot(false);

            //들어올린 오브젝트는 Canvas의 가장 마지막 자식이 됨
            transform.SetParent(Dont_Destroy_Data.Inst.Canvas);

            GetComponent<Image>().raycastTarget = false;
            dragOffset = (Vector2)transform.position - eventData.position; // 마우스 포지션 = 잡은 지점
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            transform.position = eventData.position + dragOffset; // 옮기기
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            GetComponent<Image>().raycastTarget = true;

            // 아이템을 내려놓았을 때 받아줄 슬롯이 없다면 다시 돌아옴
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
