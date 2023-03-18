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

    public void WindowSetting(string contant, UnityAction Onclick = null)
    {
        Contant.text = contant;

        CheckButton.onClick.RemoveAllListeners();
        if (Onclick != null) CheckButton.onClick.AddListener(Onclick);
        CheckButton.onClick.AddListener(SetActive_False);
    }

    void SetActive_False()
    {
        this.gameObject.SetActive(false);
    }
}
