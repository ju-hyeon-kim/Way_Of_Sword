using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public MiniMapCam_Controller MiniMapCam_Controller;
    public GameObject Quest_Guide;
    void Update()
    {
        // 
        if(MiniMapCam_Controller.Target_inScreen)
        {
            Quest_Guide.SetActive(false);
        }
        else
        {
            Quest_Guide.SetActive(true);
        }
    }
}
