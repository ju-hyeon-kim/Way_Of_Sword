using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon_Slot : Equipment_Slot
{
    public Player Player;
    public Skill_Set Skill_Set;
    public SwordObe_Slot[] SwordObe_Slots = new SwordObe_Slot[4];
    public Equipment_2D myItem;

    bool isEmpty = false;

    public void Equip_Control() //���� or ���� ����
    {
        Transform Weapon_Back = Player.Parents_of_Weapon[0].GetChild(0);
        if (Weapon_Back.gameObject.activeSelf)
        {
            //3D�󿡼� ���� ���� ����
            Weapon_Back.gameObject.SetActive(false);
            // ��ų�� ���� ��Ȱ��ȭ
            Skill_Setting(false);
            // �ҵ� ������� ����
            SwordWindow_Setting(false);
        }
        else
        {
            //3D�󿡼� ���� ����
            Weapon_Back.gameObject.SetActive(true);
            // ���갡 ������ ��Ȳ�� �°� ��ų�� Ȱ��ȭ
            Skill_Setting(true);
            // �ҵ� ������� ����
            SwordWindow_Setting(true);
        }
    }

    public void Skill_Setting(bool b)
    {
        if(b == false) //�� ��������
        {
            //��ų�� ���� ��Ȱ��ȭ
            for (int i = 0; i < 4; i++)
            {
                //Skill_Set.Skill_Icons[i].SetActive(false);
            }
        }
        else  //�� ����
        {
            //�˿� �޷��ִ� ������ ��Ȳ�� �°� ��ų ����
            for (int i = 0; i < 4; i++)
            {
                /*if(transform.GetChild(1).GetComponent<Equipment_2D>().Equipment_Data.Equipped_Obes[i] != null)
                {
                    Skill_Set.Skill_Icons[i].GetComponent<Skill_Icon>().Skill_Data = transform.GetChild(1).GetComponentInChildren<Equipment_2D>().Equipment_Data.Equipped_Obes[i].Skill_Data;
                    Skill_Set.Skill_Icons[i].SetActive(true);
                }*/
            }
        }
    }

    public void SwordWindow_Setting(bool b)
    {
        if(b == false) // ��������
        {
            for (int i = 0; i < 4; i++)
            {
                if(SwordObe_Slots[i].transform.childCount > 0)
                {
                    SwordObe_Slots[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        else // ����
        {
            for (int i = 0; i < 4; i++)
            {
                /*if (transform.GetChild(1).GetComponent<Equipment_2D>().Equipment_Data.Equipped_Obes[i] != null)
                {
                    //SwordObe_Slots[i].transform.GetChild(0).GetComponent<Obe_2D>().Obe_Data = transform.GetChild(1).GetComponentInChildren<Equipment_2D>().Equipment_Data.Equipped_Obes[i];
                    SwordObe_Slots[i].transform.GetChild(0).gameObject.SetActive(true);
                }*/
            }
        }
    }

    public float Get_WeaponAp()
    {
        if(!isEmpty)
        {
            Equipment_Data weaponData = (Equipment_Data)myItem.myData;
            return weaponData.AP;
        }
        else
        {
            return 0;
        }
    }
}
