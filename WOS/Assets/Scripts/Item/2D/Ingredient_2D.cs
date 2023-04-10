using UnityEngine;

public class Ingredient_2D : Item2D_isQuantity
{
    public override void Reset_myDataWindow()
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.IngredientData_Window;
    }
}
