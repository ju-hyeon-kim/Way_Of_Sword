using UnityEngine;

public class Obe_2D : Item_2D
{
    public override void Reset_myDataWindow()
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.ObeData_Window;
    }
}
