using System.Collections;
using System.Collections.Generic;
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
    public Image[] ObeImages;

    public override void Data_Setting(Item_2D item2D)
    {
        ItemImage.sprite = item2D.GetComponent<Image>().sprite;
        Weapon_Data Wdata = item2D.myData as Weapon_Data;
        Name.text = Wdata.Name;
        Strengthen.text = Wdata.Strengthen.ToString();
        Type.text = Wdata.Type;
        Ap.text = Wdata.Ap.ToString();
        Explanation.text = Wdata.Explanation;

        //오브의 이미지 가져오기
        for (int i = 0; i < (item2D as Weapon_2D).Equipped_Obes.Length; i++)
        {
            if((item2D as Weapon_2D).Equipped_Obes[i].TryGetComponent<Obe_2D>(out Obe_2D component)) //오브가 있다면
            {
                ObeImages[i].sprite = component.GetComponent<Image>().sprite;
            }
        }
    }
}