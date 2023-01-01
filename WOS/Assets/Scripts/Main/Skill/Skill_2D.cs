using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill_2D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler // ������ �ڵ鷯
{
    Vector2 dragOffset = Vector2.zero;
    Vector2 size = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        // ��ų�� ������ ��ų ����â�� ����
        GiveData();

        //������ ����â Ȱ��ȭ
        SkillData_Window.Inst.gameObject.SetActive(true);
        size = SkillData_Window.Inst.GetComponent<RectTransform>().sizeDelta;
        dragOffset = new Vector2(size.x * 0.5f + 0.2f, size.y * 0.5f + 0.2f);
    }

    public void OnPointerMove(PointerEventData eventData) // ���콺 �������� ������ �ȿ� ������
    {
        SkillData_Window.Inst.transform.position = eventData.position + dragOffset;
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        //������ ����â ��Ȱ��ȭ
        SkillData_Window.Inst.gameObject.SetActive(false);
    }

    public virtual void GiveData()
    {
        //�ڽ� ��ũ��Ʈ���� ������
    }
}
