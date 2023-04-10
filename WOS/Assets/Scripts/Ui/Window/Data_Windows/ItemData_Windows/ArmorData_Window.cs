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
        Armor_Data Adata = item2D.myData as Armor_Data;
        Name.text = Adata.Name;
        Strengthen.text = $"+{item2D.GetComponent<Item2D_isStrengthen>().Strengthen}";
        Type.text = ItemTypeText(item2D);
        Dp.text = $"방어력: {Adata.Stat[item2D.GetComponent<Item2D_isStrengthen>().Strengthen]}";
        Explanation.text = Adata.Explanation;
        Price.text = $"판매가격: {Adata.SellPrice}G";
    }

    string ItemTypeText(Item_2D item)
    {
        string s = "";
        Armor_Data adata = item.myData as Armor_Data;
        switch(adata.ArmorType)
        {
            case ArmorType.Boots:
                s = "신발";
                break;
            case ArmorType.Bracelet:
                s = "팔찌";
                break;
            case ArmorType.Helmet:
                s = "투구";
                break;
            case ArmorType.Necklace:
                s = "목걸이";
                break;
            case ArmorType.Pants:
                s = "하의";
                break;
            case ArmorType.Ring:
                s = "반지";
                break;
            case ArmorType.Top:
                s = "상의";
                break;
        }
        return $"장비-{s}";
    }
}
