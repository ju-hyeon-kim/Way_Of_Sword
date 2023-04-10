using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponData_Window : ItemData_Window
{
    public Image ItemImage;
    public TMP_Text Name;
    public TMP_Text Strengthen;
    public TMP_Text Ap;
    public TMP_Text Explanation;
    public TMP_Text Price;
    public Image[] ObeImages;

    public override void DataSetting_ofChild(Item_2D item2D)
    {
        ItemImage.sprite = item2D.GetComponent<Image>().sprite;
        Weapon_Data Wdata = item2D.myData as Weapon_Data;
        Name.text = Wdata.Name;

        int strengthen = item2D.GetComponent<Item2D_isStrengthen>().Strengthen;
        Strengthen.text = $"+{strengthen}";
        Ap.text = $"���ݷ�: {Wdata.Stat[strengthen]}";
        Explanation.text = Wdata.Explanation;
        Price.text = $"�ǸŰ���: {Wdata.SellPrice}G";

        //������ �̹��� ��������
        Weapon_2D Weapon2D = item2D as Weapon_2D;

        for (int i = 0; i < 4; i++)
        {
            if (Weapon2D.Equipped_Obes[i] != null) // ���갡 �ִٸ�
            {
                ObeImages[i].sprite = Weapon2D.Equipped_Obes[i].GetComponent<Image>().sprite;
                ObeImages[i].color = new Vector4(1, 1, 1, 0.6f); // ������ȭ
            }
            else
            {
                ObeImages[i].color = new Vector4(1, 1, 1, 0); // ����ȭ
            }
        }
    }
}