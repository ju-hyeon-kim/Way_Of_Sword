using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Equipment_2D : Item_2D
{
    public override void GiveData_DW() // 아이템 정보 창에 아이템 정보 건네주기
    {
        Equipment_Data edata = myData.GetComponent<Equipment_Data>(); // 스크럽터블 오브젝트는 컴포넌트를 갖고있지않기에  해당 문구 사용불가

        //이미지
        ItemData_Window.Inst.Public_Set.Image.sprite = GetComponent<Image>().sprite;
        //이름
        ItemData_Window.Inst.Public_Set.Name.text = edata.Name;

        //강화
        if (edata.Strengthen > 0)
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = $"+{edata.Strengthen}";
        }
        else
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = "";
        }
        //가격
        ItemData_Window.Inst.Public_Set.Price.text = $"판매 가격: {edata.Price} G";


        //타입
        string t = "";
        switch (edata.EquipmentType)
        {
            case EquipmentType.Weapon:
                t = "장비 - 무기";
                break;
            case EquipmentType.Necklace:
                t = "장비 - 목걸이";
                break;
            case EquipmentType.Bracelet:
                t = "장비 - 팔찌";
                break;
            case EquipmentType.Ring:
                t = "장비 - 반지";
                break;
            case EquipmentType.Helmet:
                t = "장비 - 투구";
                break;
            case EquipmentType.Top:
                t = "장비 - 상의";
                break;
            case EquipmentType.Pants:
                t = "장비 - 하의";
                break;
            case EquipmentType.Boots:
                t = "장비 - 신발";
                break;
        }
        ItemData_Window.Inst.Public_Set.Type.text = t;
        //AP
        ItemData_Window.Inst.Equipment_Set.AP.text = $"공격력: {edata.AP}";
        //설명
        ItemData_Window.Inst.Equipment_Set.Explanation_Text.text = edata.Explanation;
        //장착된 오브들
        for(int i = 0; i<4; i++)
        {
            if(edata.Equipped_Obes[i] != null)
            {
                //ItemData_Window.Inst.Equipment_Set.Equipped_Obes.Obe_Icons[i].sprite = edata.Equipped_Obes[i].Image;
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
