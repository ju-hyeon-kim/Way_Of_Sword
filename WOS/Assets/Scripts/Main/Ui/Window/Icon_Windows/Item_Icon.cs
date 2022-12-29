using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_Icon : Item_2D
{
    public Item_Data Item_Data;

    public override void GiveData() // 아이템 정보 창에 데이터 건네주기
    {
        //이미지
        ItemData_Window.Inst.Image.sprite = Item_Data.Image;
        //이름
        ItemData_Window.Inst.Name.text = Item_Data.Name;
        //타입
        ItemData_Window.Inst.Type.text = Item_Data.Type;
        //AP
        ItemData_Window.Inst.AP.text = $"공격력: {Item_Data.AP}";
        //가격
        ItemData_Window.Inst.Price.text = $"판매 가격: {Item_Data.Price} G";
        //설명
        ItemData_Window.Inst.Explanation_Text.text = Item_Data.Explanation_Text;
    }
}
