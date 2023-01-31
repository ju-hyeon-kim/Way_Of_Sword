using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obe_2D : Item_2D
{

    public void Give_Skill_Data()
    {
        Transform mySkill_Icon;

        if (transform.parent.parent.name == "SwordObe_Slots") //나의 조부모가 SwordObe_Slot이라면 스킬을 장착
        {
            mySkill_Icon = transform.parent.GetComponent<SwordObe_Slot>().mySkill_Icon;
            
            //스킬 아이콘의 이미지 적용
            //mySkill_Icon.GetComponent<Image>().sprite = myData.Skill_Sprite;
            //mySkill_Icon.transform.GetChild(0).GetComponent<Image>().sprite = myData.Skill_Sprite; // forward
            //스킬 데이타 적용
            //mySkill_Icon.GetComponent<Skill_Icon>().Skill_Data = myData.Skill_Data;
            //스킬 아이콘 활성화
            //mySkill_Icon.gameObject.SetActive(true);
        }
        else //나의 조부모가 SwordObe_Slot아니라면 스킬 장착해제
        {
            Debug.Log(Before_Parents.name);
            Before_Parents.GetComponent<SwordObe_Slot>().mySkill_Icon.gameObject.SetActive(false);
        }
    }
}
