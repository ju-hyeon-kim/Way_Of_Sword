using TMPro;
using UnityEngine.UI;


public class ObeData_Window : ItemData_Window
{
    public Image ItemImage;
    public TMP_Text ItemName;
    public TMP_Text Strengthen;
    public TMP_Text SkillName;
    public TMP_Text Explanation;
    public TMP_Text Price;

    public override void Data_Setting(Item_2D item2D)
    {
        ItemImage.sprite = item2D.GetComponent<Image>().sprite;
        Obe_Data mydata = (Obe_Data)item2D.myData;
        ItemName.text = mydata.Name;
        Strengthen.text = $"+{mydata.Strengthen}";
        SkillName.text = $"고유스킬: {mydata.Skill_2D.myData.Name}";
        Explanation.text = mydata.Skill_2D.myData.Explanation;
        Price.text = $"판매가격: {mydata.Price} G";
    }
}
