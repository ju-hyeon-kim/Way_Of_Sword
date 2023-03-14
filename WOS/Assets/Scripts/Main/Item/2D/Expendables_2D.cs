using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expendables_2D : Item2D_isQuantity
{
    public override void Reset_myDataWindow()
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.ExpendablesData_Window;
    }
}
