using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Cams : MonoBehaviour
{
    public MainCam_Controller MainCam_Controller;
    public MiniMapCam_Controller MiniMapCam_Controller;

    public void Start_Setting()
    {
        MainCam_Controller.Start_Setting();
        MiniMapCam_Controller.StartSetting();
    }
}
