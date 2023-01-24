using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Title : MonoBehaviour
{
    public void NewGame()
    {
        Manager_SceneChange.Inst.ChangeScene("Story1");
    }
}
