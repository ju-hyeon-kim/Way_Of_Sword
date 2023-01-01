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

    public void SkillSet_Conection()
    {
        GameObject mySkill;
        //나의 부모가 Sword_Slot이라면 스킬 세팅O 아니라면 스킬 세팅x
        if (transform.parent.parent.name == "SwordObe_Slots")
        {
            mySkill = transform.parent.GetComponent<SwordObe_Slot>().mySkill_Slot.GetChild(0).gameObject;

            mySkill.GetComponent<Image>().sprite = Obe_Data.Skill_Sprite;
            mySkill.transform.GetChild(0).GetComponent<Image>().sprite = Obe_Data.Skill_Sprite; // forward

            if (mySkill.activeSelf)
            {
                mySkill.SetActive(false);
            }
            else
            {
                mySkill.SetActive(true);
            }
        }
        else
        {
            mySkill = Before_Parents.GetComponent<SwordObe_Slot>().mySkill_Slot.GetChild(0).gameObject;
            if (mySkill.activeSelf)
            {
                mySkill.SetActive(false);
            }
            else
            {
                mySkill.SetActive(true);
            }
        }
    }
}
