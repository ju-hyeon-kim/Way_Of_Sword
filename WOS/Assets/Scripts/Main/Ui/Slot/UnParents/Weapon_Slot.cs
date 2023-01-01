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

    public void Equip_Control() // ���� or ���� ����
    {
        if (myNowMode == Player_Mode.Unbattle)
        {
            if (Player.Weapon_Back.GetChild(0).gameObject.activeSelf)
            {
                Player.Weapon_Back.GetChild(0).gameObject.SetActive(false);
                Skill_Setting(false); // ��������
            }
            else
            {
                Player.Weapon_Back.GetChild(0).gameObject.SetActive(true);
                Skill_Setting(true); // ����
            }
        }
    }

    public void Skill_Setting(bool b)
    {
        if(b) // �� ������ -> �˿� �޷��ִ� ������ ��Ȳ�� �°� ��ų ����
        {
            /*for (int i = 0; i < 4; i++)
            {
                Skill_Set.Skill_Icons[i].SetActive(true);
            }*/
        }
        else  // �� ���� ������ -> ��ų�� ���� ��Ȱ��ȭ
        {
            for (int i = 0; i < 4; i++)
            {
                Skill_Set.Skill_Icons[i].SetActive(false);
            }
        }
    }
}
