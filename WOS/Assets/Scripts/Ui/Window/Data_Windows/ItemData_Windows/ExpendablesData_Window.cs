using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpendablesData_Window : ItemData_Window
{
    [Header("-----ExpendablesData_Window-----")]
    public Image ItemImage;
    public TMP_Text Name;
    public TMP_Text AbillityExplanation;
    public TMP_Text Explanation;
    public TMP_Text SellPrice;

    public override void DataSetting_ofChild(Item_2D item2D)
    {
        ItemImage.sprite = item2D.GetComponent<Image>().sprite;
        Expendables_Data Idata = item2D.myData as Expendables_Data;
        Name.text = Idata.Name;
        AbillityExplanation.text = $"{Idata.AbillityExplanation} +{Idata.Ap}";
        Explanation.text = Idata.Explanation;
        SellPrice.text = $"판매가격: {Idata.SellPrice}G";
    }
}
