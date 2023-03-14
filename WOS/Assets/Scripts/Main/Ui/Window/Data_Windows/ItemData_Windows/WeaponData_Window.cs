using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponData_Window : ItemData_Window
{
    public Image ItemImage;
    public TMP_Text Name;
    public TMP_Text Strengthen;
    public TMP_Text Type;
    public TMP_Text Ap;
    public TMP_Text Explanation;
    public TMP_Text Price;
    public Image[] ObeImages;

    public override void DataSetting_ofChild(Item_2D item2D)
    {
        ItemImage.sprite = item2D.GetComponent<Image>().sprite;
        Weapon_Data Wdata = item2D.myData as Weapon_Data;
        Name.text = Wdata.Name;
        Strengthen.text = $"+{Wdata.Strengthen}";
        Type.text = Wdata.EquipnetType_Text;
        Ap.text = $"공격력: {Wdata.Ap}";
        Explanation.text = Wdata.Explanation;
        Price.text = $"판매가격: {Wdata.SellPrice}G";

        //오브의 이미지 가져오기
        Weapon_2D Weapon2D = item2D as Weapon_2D;

        for (int i = 0; i < 4; i++)
        {
            if (Weapon2D.Equipped_Obes[i] != null) // 오브가 있다면
            {
                ObeImages[i].sprite = Weapon2D.Equipped_Obes[i].GetComponent<Image>().sprite;
                ObeImages[i].color = new Vector4(1, 1, 1, 0.6f); // 반투명화
            }
            else
            {
                ObeImages[i].color = new Vector4(1, 1, 1, 0); // 투명화
            }
        }
    }
}