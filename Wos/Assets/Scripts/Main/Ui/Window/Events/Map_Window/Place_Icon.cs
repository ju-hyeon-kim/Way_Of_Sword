using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Place_Icon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Animator myLabel_Image;
    public GameObject myLock;
    public TeleportQuestion_Window TQ_Window;
    public NowPos_Icon NowPos_Icon;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name != gameObject.name && myLock.activeSelf == false)
        {
            NowPos_Icon.ChangePos(this.transform);
            TQ_Window.Place_Check(this.gameObject);
            TQ_Window.gameObject.SetActive(true);
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
