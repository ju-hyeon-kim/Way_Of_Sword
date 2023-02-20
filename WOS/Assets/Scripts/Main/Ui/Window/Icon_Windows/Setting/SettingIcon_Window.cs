using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingIcon_Window : Icon_Window
{
    public GameObject GoTitle_Window;

    public void GoTitle_Button()
    {
        GoTitle_Window.SetActive(true);
    }
}
