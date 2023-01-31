using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient_2D : Item_2D
{
    public override void GiveData_DW()
    {
        Ingredient_Data mydata = myData.GetComponent<Ingredient_Data>(); // 스크럽터블 오브젝트는 컴포넌트를 갖고있지않기에  해당 문구 사용불가

        //이미지
        ItemData_Window.Inst.Public_Set.Image.sprite = GetComponent<Image>().sprite;
        //이름
        ItemData_Window.Inst.Public_Set.Name.text = mydata.Name;
        //가격
        ItemData_Window.Inst.Public_Set.Price.text = $"판매 가격: {mydata.Price} G";


        //타입
        ItemData_Window.Inst.Public_Set.Type.text = "재료";
        //설명
        ItemData_Window.Inst.Ingredient_Set.Explanation_Text.text = mydata.Explanation;


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
