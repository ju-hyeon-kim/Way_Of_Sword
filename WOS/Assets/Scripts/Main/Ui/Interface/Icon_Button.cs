using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_Button : MonoBehaviour //부모
{
    public GameObject myWindow;

    public void Window_OnOff()
    {
        //가장 마지막 자식으로 이동
        myWindow.transform.SetAsLastSibling();

        if(myWindow.activeSelf)
        {
            myWindow.SetActive(false);
        }
        else
        {
            myWindow.SetActive(true);
        }   
    }
}
