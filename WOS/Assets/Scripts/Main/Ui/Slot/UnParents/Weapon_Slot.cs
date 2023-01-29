using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon_Slot : MonoBehaviour
{
    public Player_Main Player;
    public Skill_Set Skill_Set;
    public SwordObe_Slot[] SwordObe_Slots = new SwordObe_Slot[4];

    public void Equip_Control() //장착 or 장착 해제
    {
        if (Player.Weapon_Back.GetChild(0).gameObject.activeSelf)
        {
            //3D상에서 무기 장착 해제
            Player.Weapon_Back.GetChild(0).gameObject.SetActive(false);
            // 스킬셋 전부 비활성화
            Skill_Setting(false);
            // 소드 윈도우와 연동
            SwordWindow_Setting(false);
        }
        else
        {
            //3D상에서 무기 장착
            Player.Weapon_Back.GetChild(0).gameObject.SetActive(true);
            // 오브가 장착된 상황에 맞게 스킬셋 활성화
            Skill_Setting(true);
            // 소드 윈도우와 연동
            SwordWindow_Setting(true);
        }
    }

    public void Skill_Setting(bool b)
    {
        if(b == false) //검 장착해제
        {
            //스킬셋 전부 비활성화
            for (int i = 0; i < 4; i++)
            {
                Skill_Set.Skill_Icons[i].SetActive(false);
            }
        }
        else  //검 장착
        {
            //검에 달려있는 오브의 상황에 맞게 스킬 세팅
            for (int i = 0; i < 4; i++)
            {
                if(transform.GetChild(1).GetComponent<Equipment_2D>().Equipment_Data.Equipped_Obes[i] != null)
                {
                    Skill_Set.Skill_Icons[i].GetComponent<Skill_Icon>().Skill_Data = transform.GetChild(1).GetComponentInChildren<Equipment_2D>().Equipment_Data.Equipped_Obes[i].Skill_Data;
                    Skill_Set.Skill_Icons[i].SetActive(true);
                }
            }
        }
    }

    public void SwordWindow_Setting(bool b)
    {
        if(b == false) // 장착해제
        {
            for (int i = 0; i < 4; i++)
            {
                if(SwordObe_Slots[i].transform.childCount > 0)
                {
                    SwordObe_Slots[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        else // 장착
        {
            for (int i = 0; i < 4; i++)
            {
                if (transform.GetChild(1).GetComponent<Equipment_2D>().Equipment_Data.Equipped_Obes[i] != null)
                {
                    //SwordObe_Slots[i].transform.GetChild(0).GetComponent<Obe_2D>().Obe_Data = transform.GetChild(1).GetComponentInChildren<Equipment_2D>().Equipment_Data.Equipped_Obes[i];
                    SwordObe_Slots[i].transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
    }
}
