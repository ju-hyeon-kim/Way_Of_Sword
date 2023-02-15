using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon_2D : Item_2D
{
    public Transform[] Equipped_Obes = new Transform[4];

    public override void OnPointerEnter(PointerEventData eventData)
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.WeaponData_Window;
        myData_Window.Data_Setting(this);
        myData_Window.gameObject.SetActive(true);
    }
}
