using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_Icon : Item_2D
{
    public Sprite myImage;
    public Item.Type myType = default;
    public string Name;
    public float AP;
    public float Price;
    public string Document_Text;

    public override void GiveData()
    {
        ItemData_Window.Inst.Image.sprite = myImage;

        string type;
        switch(myType)
        {
            case Item.Type.Equipment:
                type = "���";
                break;
            case Item.Type.Expendables:
                type = "�Ҹ�ǰ";
                break;
            case Item.Type.Ingredient:
                type = "���";
                break;
        }
        //ItemData_Window.Inst.Image.type = myImage;
    }
}
