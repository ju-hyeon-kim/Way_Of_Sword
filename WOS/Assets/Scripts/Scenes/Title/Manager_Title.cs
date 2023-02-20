using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Title : MonoBehaviour
{
    public GameObject NewGame_Window;

    public void NewGame_Button()
    {
        NewGame_Window.SetActive(true);
    }
}
