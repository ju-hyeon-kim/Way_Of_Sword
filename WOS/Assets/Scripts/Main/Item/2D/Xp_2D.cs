using UnityEngine.EventSystems;

public class Xp_2D : Item_2D
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.XpData_Window;
        myData_Window.Data_Setting(this);
        myData_Window.gameObject.SetActive(true);
    }
}
