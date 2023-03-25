using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Notice_Window : MonoBehaviour
{
    public TMP_Text Contant;
    public Button CheckButton;
    public GameObject[] Effcet_Images; 

    public void WindowSetting(string contant, UnityAction onclick = null, int effect = -1) // effect -> -1:효과없음 0:실패효과 1:성공효과
    {
        Contant.text = contant;

        CheckButton.onClick.RemoveAllListeners();
        if (onclick != null) CheckButton.onClick.AddListener(onclick);
        CheckButton.onClick.AddListener(SetActive_False);

        if(effect != -1)
        {
            Effcet_Images[effect].SetActive(true);
        }
    }

    void SetActive_False()
    {
        Effcet_Images[0].SetActive(false);
        Effcet_Images[1].SetActive(false);
        this.gameObject.SetActive(false);
    }
}
