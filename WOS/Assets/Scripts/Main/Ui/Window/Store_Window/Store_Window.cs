using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Store_Window : Window, IPointerEnterHandler, IPointerExitHandler
{
    public Transform[] Taps;
    public Image[] NameTags;

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

    public void Push_NameTag(int tapnum)
    {
        //NameTag
        
        for(int i = 0; i < NameTags.Length; i++)
        {
            if(i == tapnum)
            {
                NameTags[i].color = Color.white;
                NameTags[i].maskable = false;
            }
            else
            {
                NameTags[i].color = new Color(0.6f, 0.6f, 0.6f);
                NameTags[i].maskable = true;
            }
        }
        //Taps
        Taps[tapnum].SetAsLastSibling();
    }
}
