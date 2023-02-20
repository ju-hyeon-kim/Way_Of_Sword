using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame_Window : MonoBehaviour
{
    public void Yes_Button()
    {
        Manager_SceneChange.Inst.ChangeScene("Village");
    }
}
