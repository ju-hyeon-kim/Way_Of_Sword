using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_Icon : Item_2D
{
    public Item_Data Item_Data;

    public override void GiveData() // 아이템 정보 창에 아이템 정보 건네주기
    {
        //이미지
        ItemData_Window.Inst.Image.sprite = Item_Data.Image;
        //이름
        ItemData_Window.Inst.Name.text = Item_Data.Name;
        //타입
        string t ="";
        switch(Item_Data.ItemType)
        {
            case Item.Type.Equipment:
                switch(Item_Data.EquipmentType)
                {
                    case Item.EquipmentType.Weapon:
                        t = "장비 - 무기";
                        break;
                    case Item.EquipmentType.Necklace:
                        t = "장비 - 목걸이";
                        break;
                    case Item.EquipmentType.Bracelet:
                        t = "장비 - 팔찌";
                        break;
                    case Item.EquipmentType.Ring:
                        t = "장비 - 반지";
                        break;
                    case Item.EquipmentType.Helmet:
                        t = "장비 - 투구";
                        break;
                    case Item.EquipmentType.Top:
                        t = "장비 - 상의";
                        break;
                    case Item.EquipmentType.Pants:
                        t = "장비 - 하의";
                        break;
                    case Item.EquipmentType.Boots:
                        t = "장비 - 신발";
                        break;
                }
                break;
            case Item.Type.Obe:
                t = "오브";
                break;
            case Item.Type.Expendables:
                t = "소모품";
                break;
            case Item.Type.Ingredient:
                t = "재료";
                break;
        }
        ItemData_Window.Inst.Type.text = t;
        //AP
        ItemData_Window.Inst.AP.text = $"공격력: {Item_Data.AP}";
        //가격
        ItemData_Window.Inst.Price.text = $"판매 가격: {Item_Data.Price} G";
        //설명
        ItemData_Window.Inst.Explanation_Text.text = Item_Data.Explanation_Text;
    }
}
