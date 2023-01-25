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

    public void OnPointerEnter(PointerEventData eventData) // 마우스 포지션이 아이콘 안으로 들어왔을때
    {
        myLabel_Image.SetBool("Open", true);
    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포지션이 아이콘 밖으로 빠져나갈 때
    {
        myLabel_Image.SetBool("Open", false);
    }
}
