using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientData_Window : ItemData_Window
{
    public Image Image;
    public TMP_Text Name;
    public TMP_Text Explanation;

    public override void Data_Setting(Item_2D item2D)
    {
        Image.sprite = item2D.transform.GetComponent<Image>().sprite;

        Ingredient_Data mydata = (Ingredient_Data)item2D.myData;
        Name.text = mydata.Name;
        Explanation.text = mydata.Explanation;
    }
}
