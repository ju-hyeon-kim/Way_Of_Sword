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

        if (transform.parent.parent.name == "SwordObe_Slots") //���� ���θ� SwordObe_Slot�̶�� ��ų�� ����
        {
            mySkill_Icon = transform.parent.GetComponent<SwordObe_Slot>().mySkill_Icon;
            
            //��ų �������� �̹��� ����
            //mySkill_Icon.GetComponent<Image>().sprite = myData.Skill_Sprite;
            //mySkill_Icon.transform.GetChild(0).GetComponent<Image>().sprite = myData.Skill_Sprite; // forward
            //��ų ����Ÿ ����
            //mySkill_Icon.GetComponent<Skill_Icon>().Skill_Data = myData.Skill_Data;
            //��ų ������ Ȱ��ȭ
            //mySkill_Icon.gameObject.SetActive(true);
        }
        else //���� ���θ� SwordObe_Slot�ƴ϶�� ��ų ��������
        {
            Debug.Log(Before_Parents.name);
            Before_Parents.GetComponent<SwordObe_Slot>().mySkill_Icon.gameObject.SetActive(false);
        }
    }
}
