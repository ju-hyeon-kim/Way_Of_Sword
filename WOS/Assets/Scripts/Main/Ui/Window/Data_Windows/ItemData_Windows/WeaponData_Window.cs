using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public SwordIcon_Window SwordIcon_Window;

    public override void Data_Setting(Item_2D item2D)
    {
        ItemImage.sprite = item2D.GetComponent<Image>().sprite;
        Weapon_Data Wdata = item2D.myData as Weapon_Data;
        Name.text = Wdata.Name;
        Strengthen.text = $"+{Wdata.Strengthen}";
        Type.text = Wdata.EquipnetType_Text;
        Ap.text = $"공격력: {Wdata.Ap}";
        Explanation.text = Wdata.Explanation;

        //오브의 이미지 가져오기
        for(int i = 0; i < SwordIcon_Window.ObeSlots.Length; i++)
        {
            if(!SwordIcon_Window.ObeSlots[i].isEmpty)
            {
                ObeImages[i].sprite = SwordIcon_Window.ObeSlots[i].myObe.GetComponent<Image>().sprite;
                ObeImages[i].color = new Vector4(1, 1, 1, 0.6f); // 반투명화
            }
            else
            {
                ObeImages[i].color = new Vector4(1, 1, 1, 0); // 투명화
            }
        }
    }
}