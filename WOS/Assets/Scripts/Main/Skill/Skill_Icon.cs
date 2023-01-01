using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill_Icon : Skill_2D
{
    public Skill_Data Skill_Data;
    public Image myForward;

    public override void GiveData() // ������ ���� â�� ������ ���� �ǳ��ֱ�
    {
        //�̹���
        SkillData_Window.Inst.Image.sprite = Skill_Data.Image;
        //�̸�
        SkillData_Window.Inst.Name.text = Skill_Data.Name;
        //��ų ����
        SkillData_Window.Inst.Skill_Explanation.text = Skill_Data.Skill_Explanation;
    }
}