using TMPro;
using UnityEngine.UI;

public class XpGoldData_Window : ItemData_Window
{
    public Image Image;
    public TMP_Text Name;
    public TMP_Text Price;

    public override void Data_Setting(Item_2D item2D)
    {
        Image.sprite = item2D.GetComponent<Image>().sprite;
        XpGold_Data mydata = (XpGold_Data)item2D.myData;
        Name.text = mydata.Name;
        Price.text = $"{mydata.Price} xp";
    }
}
