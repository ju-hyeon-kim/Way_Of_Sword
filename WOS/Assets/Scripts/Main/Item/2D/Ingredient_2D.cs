using UnityEngine.EventSystems;

public class Ingredient_2D : Item_2D
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.IngredientData_Window;
        myData_Window.Data_Setting(this);
        myData_Window.gameObject.SetActive(true);
    }
}
