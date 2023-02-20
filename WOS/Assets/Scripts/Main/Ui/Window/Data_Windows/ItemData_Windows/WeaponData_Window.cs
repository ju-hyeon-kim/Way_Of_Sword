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
        Ap.text = $"���ݷ�: {Wdata.Ap}";
        Explanation.text = Wdata.Explanation;

        //������ �̹��� ��������
        for(int i = 0; i < SwordIcon_Window.ObeSlots.Length; i++)
        {
            if(!SwordIcon_Window.ObeSlots[i].isEmpty)
            {
                ObeImages[i].sprite = SwordIcon_Window.ObeSlots[i].myObe.GetComponent<Image>().sprite;
                ObeImages[i].color = new Vector4(1, 1, 1, 0.6f); // ������ȭ
            }
            else
            {
                ObeImages[i].color = new Vector4(1, 1, 1, 0); // ����ȭ
            }
        }
    }
}