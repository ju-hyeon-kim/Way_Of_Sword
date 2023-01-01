using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Slot : MonoBehaviour
{
    public Player_Main Player;
    public Skill_Set Skill_Set;

    Player_Mode myNowMode = Player_Mode.None;

    private void Start()
    {
        myNowMode = Player.NowMode;
    }

    public void Equip_Control() // 장착 or 장착 해제
    {
        if (myNowMode == Player_Mode.Unbattle)
        {
            if (Player.Weapon_Back.GetChild(0).gameObject.activeSelf)
            {
                Player.Weapon_Back.GetChild(0).gameObject.SetActive(false);
                Skill_Setting(false); // 장착해제
            }
            else
            {
                Player.Weapon_Back.GetChild(0).gameObject.SetActive(true);
                Skill_Setting(true); // 장착
            }
        }
    }

    public void Skill_Setting(bool b)
    {
        if(b) // 검 장착시 -> 검에 달려있는 오브의 상황에 맞게 스킬 세팅
        {
            /*for (int i = 0; i < 4; i++)
            {
                Skill_Set.Skill_Icons[i].SetActive(true);
            }*/
        }
        else  // 검 장착 해제시 -> 스킬셋 전부 비활성화
        {
            for (int i = 0; i < 4; i++)
            {
                Skill_Set.Skill_Icons[i].SetActive(false);
            }
        }
    }
}
