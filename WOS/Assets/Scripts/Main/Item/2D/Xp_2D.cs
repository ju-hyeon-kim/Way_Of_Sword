using UnityEngine.EventSystems;

public class Xp_2D : Item_2D
{
    public override void Reset_myDataWindow()
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.XpData_Window;
    }
}
