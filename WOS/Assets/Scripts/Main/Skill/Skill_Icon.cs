using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Icon : Skill_2D
{
    public Skill_Data Skill_Data;
    public Image myForward;

    public override void GiveData() // 아이템 정보 창에 아이템 정보 건네주기
    {
        //이미지
        SkillData_Window.Inst.Image.sprite = Skill_Data.Image;
        //이름
        SkillData_Window.Inst.Name.text = Skill_Data.Name;
        //스킬 설명
        SkillData_Window.Inst.Skill_Explanation.text = Skill_Data.Skill_Explanation;
    }
}