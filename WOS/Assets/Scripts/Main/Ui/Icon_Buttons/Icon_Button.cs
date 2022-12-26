using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_Button : MonoBehaviour //ºÎ¸ð
{
    public GameObject myWindow;
    bool window_act = false;

    public void Window_OnOff()
    {
        if(!window_act)
        {
            myWindow.SetActive(true);
            window_act = true;
        }
        else
        {
            myWindow.SetActive(false);
            window_act = false;
        }   
    }
}
