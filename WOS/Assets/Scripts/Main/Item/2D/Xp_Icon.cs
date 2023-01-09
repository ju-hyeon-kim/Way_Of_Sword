using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class Xp_Icon : Item_Icon
{
    public Xp_Data Xp_Data;

    public override void GiveData()
    {
        //이미지
        ItemData_Window.Inst.Public_Set.Image.sprite = Xp_Data.Image;
        //이름
        ItemData_Window.Inst.Public_Set.Name.text = Xp_Data.Name;
        //수치

        //아이템 데이타 윈도우 활성화 ( myType에 따라 Set를 정해줌 )
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
