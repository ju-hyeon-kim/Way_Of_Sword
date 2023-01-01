using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill_2D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler // 포인터 핸들러
{
    Vector2 dragOffset = Vector2.zero;
    Vector2 size = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData) // 마우스 포지션이 아이콘 안으로 들어왔을때
    {
        // 스킬의 정보를 스킬 정보창에 전달
        GiveData();

        //아이템 정보창 활성화
        SkillData_Window.Inst.gameObject.SetActive(true);
        size = SkillData_Window.Inst.GetComponent<RectTransform>().sizeDelta;
        dragOffset = new Vector2(size.x * 0.5f + 0.2f, size.y * 0.5f + 0.2f);
    }

    public void OnPointerMove(PointerEventData eventData) // 마우스 포지션이 아이콘 안에 있을때
    {
        SkillData_Window.Inst.transform.position = eventData.position + dragOffset;
    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포지션이 아이콘 밖으로 빠져나갈 때
    {
        //아이템 정보창 비활성화
        SkillData_Window.Inst.gameObject.SetActive(false);
    }

    public virtual void GiveData()
    {
        //자식 스크립트에서 재정의
    }
}
