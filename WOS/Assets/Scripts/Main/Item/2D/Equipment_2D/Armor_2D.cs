using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_2D : Item_2D
{
    //[Header("-----Armor_2D-----")]

    public override void Reset_myDataWindow()
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.ArmorData_Window;
    }
}
