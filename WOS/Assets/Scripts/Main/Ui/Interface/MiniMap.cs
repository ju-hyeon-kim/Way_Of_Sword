using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public bool Update_Active = true;
    public MiniMapCam_Controller MiniMapCam_Controller;
    public GameObject Quest_Guide;

    private void Start()
    {
        Manager_SceneChange.inst.MiniMap = this;
    }

    private void Update()
    {
        if(Update_Active)
        {
            if(!MiniMapCam_Controller.Target_inScreen)
            {
                Quest_Guide.SetActive(true);
            }
            else
            {
                Quest_Guide.SetActive(false);
            }
        }
        else
        {
            Quest_Guide.SetActive(false);
        }
    }

}
