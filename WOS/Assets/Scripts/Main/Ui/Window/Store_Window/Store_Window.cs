using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Store_Window : Window, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.Zoom_Possible_OnOff(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.Zoom_Possible_OnOff(true);
    }

    public void ExitButton()
    {
        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.Zoom_Possible_OnOff(true);
        this.gameObject.SetActive(false);
    }
}
