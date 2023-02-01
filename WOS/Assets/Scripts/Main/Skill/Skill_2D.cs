using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill_2D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler // 포인터 핸들러
{
    public Skill_Data myData;

    SkillData_Window SDwindow;
    Vector2 dragOffset = Vector2.zero;
    Vector2 size = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData) // 마우스 포지션이 아이콘 안으로 들어왔을때
    {
        SDwindow = this.transform.parent.GetComponent<Skill_Slot>().SkillData_Window;
        SDwindow.Data_Setting(this);
        SDwindow.gameObject.SetActive(true);
    }

    public void OnPointerMove(PointerEventData eventData) // 마우스 포지션이 아이콘 안에 있을때
    {
        SDwindow.Updating_Position(eventData);
    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포지션이 아이콘 밖으로 빠져나갈 때
    {
        SDwindow.gameObject.SetActive(false);
    }
}
