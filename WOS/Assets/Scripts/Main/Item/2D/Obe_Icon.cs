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

    public void Give_Skill_Data()
    {
        Transform mySkill_Icon;

        if (transform.parent.parent.name == "SwordObe_Slots") //���� ���θ� SwordObe_Slot�̶�� ��ų�� ����
        {
            mySkill_Icon = transform.parent.GetComponent<SwordObe_Slot>().mySkill_Icon;
            
            //��ų �������� �̹��� ����
            mySkill_Icon.GetComponent<Image>().sprite = Obe_Data.Skill_Sprite;
            mySkill_Icon.transform.GetChild(0).GetComponent<Image>().sprite = Obe_Data.Skill_Sprite; // forward
            //��ų ����Ÿ ����
            mySkill_Icon.GetComponent<Skill_Icon>().Skill_Data = Obe_Data.Skill_Data;
            //��ų ������ Ȱ��ȭ
            mySkill_Icon.gameObject.SetActive(true);
        }
        else //���� ���θ� SwordObe_Slot�ƴ϶�� ��ų ��������
        {
            Debug.Log(Before_Parents.name);
            Before_Parents.GetComponent<SwordObe_Slot>().mySkill_Icon.gameObject.SetActive(false);
        }
    }
}
