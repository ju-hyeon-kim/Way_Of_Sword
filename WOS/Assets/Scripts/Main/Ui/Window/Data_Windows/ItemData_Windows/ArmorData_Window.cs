using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ArmorData_Window : ItemData_Window
{
    [Header("-----ArmorData_Window-----")]
    public Image ItemImage;
    public TMP_Text Name;
    public TMP_Text Strengthen;
    public TMP_Text Type;
    public TMP_Text Dp;
    public TMP_Text Explanation;
    public TMP_Text Price;

    public override void DataSetting_ofChild(Item_2D item2D)
    {
        ItemImage.sprite = item2D.GetComponent<Image>().sprite;
        Armor_Data Wdata = item2D.myData as Armor_Data;
        Name.text = Wdata.Name;
        Strengthen.text = $"+{Wdata.Strengthen}";
        Type.text = Wdata.EquipnetType_Text;
        Dp.text = $"방어력: {Wdata.Dp}";
        Explanation.text = Wdata.Explanation;
        Price.text = $"판매가격: {Wdata.SellPrice}G";
    }
}
