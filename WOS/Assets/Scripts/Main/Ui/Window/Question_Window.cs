using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Question_Window : MonoBehaviour
{
    public TMP_Text Contant;
    public Button YButton;
    public Button NButton;

    public void WindowSetting(string contant, UnityAction Y_Onclick = null, UnityAction N_Onclick = null)
    {
        Contant.text = contant;

        YButton.onClick.RemoveAllListeners();
        if(Y_Onclick != null) YButton.onClick.AddListener(Y_Onclick);
        YButton.onClick.AddListener(SetActive_False);

        NButton.onClick.RemoveAllListeners();
        if(N_Onclick != null) NButton.onClick.AddListener(N_Onclick);
        NButton.onClick.AddListener(SetActive_False);
    }

    void SetActive_False()
    {
        this.gameObject.SetActive(false);
    }
}