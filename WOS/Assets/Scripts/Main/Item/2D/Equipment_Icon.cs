using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Equipment_Icon : Item_Icon
{
    public Equipment_Data Equipment_Data;

    
    public override void GiveData() // 아이템 정보 창에 아이템 정보 건네주기
    {
        //이미지
        ItemData_Window.Inst.Public_Set.Image.sprite = Equipment_Data.Image;
        //이름
        ItemData_Window.Inst.Public_Set.Name.text = Equipment_Data.Name;

        //강화
        if (Equipment_Data.Strengthen > 0)
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = $"+{Equipment_Data.Strengthen}";
        }
        else
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = "";
        }
        //가격
        ItemData_Window.Inst.Public_Set.Price.text = $"판매 가격: {Equipment_Data.Price} G";


        //타입
        string t = "";
        switch (Equipment_Data.EquipmentType)
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
        ItemData_Window.Inst.Public_Set.Type.text = t;
        //AP
        ItemData_Window.Inst.Equipment_Set.AP.text = $"공격력: {Equipment_Data.AP}";
        //설명
        ItemData_Window.Inst.Equipment_Set.Explanation_Text.text = Equipment_Data.Explanation_Text;
        //장착된 오브들
        for(int i = 0; i<4; i++)
        {
            if(Equipment_Data.Equipped_Obes[i] != null)
            {
                ItemData_Window.Inst.Equipment_Set.Equipped_Obes.Obe_Icons[i].sprite = Equipment_Data.Equipped_Obes[i].Image;
                ItemData_Window.Inst.Equipment_Set.Equipped_Obes.Obe_Icons[i].gameObject.SetActive(true);
            }
            else
            {
                ItemData_Window.Inst.Equipment_Set.Equipped_Obes.Obe_Icons[i].gameObject.SetActive(false);
            }
        }
        

        //아이템 타입에 맞는 세팅 창을 활성화
        for (int i = 0; i < 4; i++)
        {
            ItemData_Window.Inst.Type_Sets[i].SetActive(false);
            if (i == (int)myType)
            {
                ItemData_Window.Inst.Type_Sets[i].SetActive(true);
            }
        }
    }
}
