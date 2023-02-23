using TMPro;
using UnityEngine.UI;

public class IngredientData_Window : ItemData_Window
{
    public Image Image;
    public TMP_Text Name;
    public TMP_Text Explanation;
    public TMP_Text Price;

    public override void Data_Setting(Item_2D item2D)
    {
        Image.sprite = item2D.transform.GetComponent<Image>().sprite;

        Ingredient_Data mydata = (Ingredient_Data)item2D.myData;
        Name.text = mydata.Name;
        Explanation.text = mydata.Explanation;
        Price.text = $"판매가격: {mydata.Price}";
    }
}
