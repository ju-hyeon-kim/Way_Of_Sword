using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obe_2D : Item_2D
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.ObeData_Window;
    }
}
