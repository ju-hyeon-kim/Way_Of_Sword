using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obe_Icon : Item_Icon
{
    public Obe_Data Obe_Data;

    int typenum = 1;
    public override void GiveData() // 아이템 정보 창에 아이템 정보 건네주기
    {
        //이미지
        ItemData_Window.Inst.Public_Set.Image.sprite = Obe_Data.Image;
        //이름
        ItemData_Window.Inst.Public_Set.Name.text = Obe_Data.Name;
        //강화
        //강화
        if (Obe_Data.Strengthen > 0)
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = $"+{Obe_Data.Strengthen}";
        }
        else
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = "";
        }
        //가격
        ItemData_Window.Inst.Public_Set.Price.text = $"판매 가격: {Obe_Data.Price} G";
        //타입
        ItemData_Window.Inst.Public_Set.Type.text = "오브";
        //고유 스킬
        ItemData_Window.Inst.Obe_Set.Obe_Skill.text = $"고유 스킬 : {Obe_Data.Obe_Skill}";
        //스킬 이름
        ItemData_Window.Inst.Obe_Set.Skill_Name.text = Obe_Data.Obe_Skill;
        //스킬 설명
        ItemData_Window.Inst.Obe_Set.Skill_Explanation.text = Obe_Data.Skill_Explanation;

        //아이템 타입에 맞는 세팅 창을 활성화
        for (int i = 0; i < 4; i++)
        {
            ItemData_Window.Inst.Type_Sets[i].SetActive(false);
            if (i == typenum)
            {
                ItemData_Window.Inst.Type_Sets[i].SetActive(true);
            }
        }
    }

    public override void myType_Set()
    {
        myType = Obe_Data.ItemType;
    }

    public void Give_Skill_Data()
    {
        Transform mySkill_Icon;

        if (transform.parent.parent.name == "SwordObe_Slots") //나의 조부모가 SwordObe_Slot이라면 스킬을 장착
        {
            mySkill_Icon = transform.parent.GetComponent<SwordObe_Slot>().mySkill_Icon;
            
            //스킬 아이콘의 이미지 적용
            mySkill_Icon.GetComponent<Image>().sprite = Obe_Data.Skill_Sprite;
            mySkill_Icon.transform.GetChild(0).GetComponent<Image>().sprite = Obe_Data.Skill_Sprite; // forward
            //스킬 데이타 적용
            mySkill_Icon.GetComponent<Skill_Icon>().Skill_Data = Obe_Data.Skill_Data;
            //스킬 아이콘 활성화
            mySkill_Icon.gameObject.SetActive(true);
        }
        else //나의 조부모가 SwordObe_Slot아니라면 스킬 장착해제
        {
            Debug.Log(Before_Parents.name);
            Before_Parents.GetComponent<SwordObe_Slot>().mySkill_Icon.gameObject.SetActive(false);
        }
    }
}
