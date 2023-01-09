using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

// 마우스 포인터, 핸들러
public class Icon_2D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public void OnPointerEnter(PointerEventData eventData) // 마우스 포지션이 아이콘 안으로 들어왔을때
    {
        // Data Window에게 Data를 전달
        GiveData_DW();

        //아이템 정보창 활성화
        Show_DataWindow();

        /*ItemData_Window.Inst.gameObject.SetActive(true);
        size = ItemData_Window.Inst.GetComponent<RectTransform>().sizeDelta;
        dragOffset = new Vector2(size.x * 0.5f + 0.2f, size.y * 0.5f + 0.2f);*/
    }

    public void OnPointerMove(PointerEventData eventData) // 마우스 포지션이 아이콘 안에 있을때
    {
        //ItemData_Window.Inst.transform.position = eventData.position + dragOffset;
    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포지션이 아이콘 밖으로 빠져나갈 때
    {
        //아이템 정보창 비활성화
        //ItemData_Window.Inst.gameObject.SetActive(false);
    }

    public virtual void GiveData_DW()
    {

    }

    public virtual void Show_DataWindow()
    {

    }
}
