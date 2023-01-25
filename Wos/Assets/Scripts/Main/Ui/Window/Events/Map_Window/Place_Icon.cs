using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Place_Icon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Animator myLabel_Image;
    public GameObject myLock;
    public Question_Window Question_Window;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(myLock.activeSelf == false)
        {
            Question_Window.Place_Check(gameObject.name);
            Question_Window.transform.parent.gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        myLabel_Image.SetBool("Open", true);
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        myLabel_Image.SetBool("Open", false);
    }
}
