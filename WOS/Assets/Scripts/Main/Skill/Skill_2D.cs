using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill_2D : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler // ������ �ڵ鷯
{
    public Skill_Data myData;
    public Image myCoolTime_Img;
    bool isCoolTime = false;

    SkillData_Window SDwindow;
    Vector2 dragOffset = Vector2.zero;
    Vector2 size = Vector2.zero;

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        SDwindow = this.transform.parent.GetComponent<Skill_Slot>().SkillData_Window;
        SDwindow.Data_Setting(this);
        SDwindow.gameObject.SetActive(true);
    }

    public void OnPointerMove(PointerEventData eventData) // ���콺 �������� ������ �ȿ� ������
    {
        SDwindow.Updating_Position(eventData);
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        SDwindow.gameObject.SetActive(false);
    }

    public void OnCoolTime()
    {
        StartCoroutine(CoolTime_Checking());
    }

    IEnumerator CoolTime_Checking()
    {
        isCoolTime = true;
        myCoolTime_Img.fillAmount = 1;
        float cooltime = myData.CoolTime;

        while (cooltime > 0)
        {
            cooltime -= Time.deltaTime;
            myCoolTime_Img.fillAmount = cooltime / myData.CoolTime;
            yield return null;
        }
        isCoolTime = false;
    }

    public bool Get_isCoolTime()
    {
        return isCoolTime;
    }
}
