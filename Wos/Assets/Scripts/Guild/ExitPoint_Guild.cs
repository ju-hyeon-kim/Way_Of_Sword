using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint_Guild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Manager_SceneChange.Inst.Before_Place == "Guild")
        {
            Manager_SceneChange.Inst.player.transform.position = transform.position;
        }
    }
}
