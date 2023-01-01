using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obe_Icon : Item_Icon
{
    public Obe_Data Obe_Data;

    int typenum = 1;
    public override void GiveData() // ������ ���� â�� ������ ���� �ǳ��ֱ�
    {
        //�̹���
        ItemData_Window.Inst.Public_Set.Image.sprite = Obe_Data.Image;
        //�̸�
        ItemData_Window.Inst.Public_Set.Name.text = Obe_Data.Name;
        //��ȭ
        //��ȭ
        if (Obe_Data.Strengthen > 0)
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = $"+{Obe_Data.Strengthen}";
        }
        else
        {
            ItemData_Window.Inst.Obe_Set.Strengthem.text = "";
        }
        //����
        ItemData_Window.Inst.Public_Set.Price.text = $"�Ǹ� ����: {Obe_Data.Price} G";
        //Ÿ��
        ItemData_Window.Inst.Public_Set.Type.text = "����";
        //���� ��ų
        ItemData_Window.Inst.Obe_Set.Obe_Skill.text = $"���� ��ų : {Obe_Data.Obe_Skill}";
        //��ų �̸�
        ItemData_Window.Inst.Obe_Set.Skill_Name.text = Obe_Data.Obe_Skill;
        //��ų ����
        ItemData_Window.Inst.Obe_Set.Skill_Explanation.text = Obe_Data.Skill_Explanation;

        //������ Ÿ�Կ� �´� ���� â�� Ȱ��ȭ
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
        //���� �θ� Sword_Slot�̶�� ��ų ����O �ƴ϶�� ��ų ����x
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
