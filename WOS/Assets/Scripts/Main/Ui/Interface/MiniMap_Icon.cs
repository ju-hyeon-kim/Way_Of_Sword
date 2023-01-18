using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_Icon : MonoBehaviour
{
    public int Icons_Num;

    void Start()
    {
        Manager_SceneChange.inst.MiniMapCam_Controller.MiniMap_Icons[Icons_Num] = transform;
    }
}
