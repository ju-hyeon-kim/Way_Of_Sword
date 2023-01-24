using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Player_Mode
{
    None, Battle, Unbattle
}

public class Player_Main : Player_Movement
{
    public Player_Mode NowMode = Player_Mode.None;

    public GameObject Skill_Range;
    public Transform Weapon_Back;
    public Transform Weapon_Hand;
    public Transform Cam_Target;
    
    public NpcTalk_Window NpcTalk_Window;

    void ChangeMode(Player_Mode pm)
    {
        NowMode = pm;
        switch (pm)
        { 
            case Player_Mode.Unbattle: // ���Ʋ ����� ���
                //������ ��ġ�� �� -> �� �ڷ� �̵� (����ó��?: ���� �̹� ���Ⱑ �� �ڿ� �ִٸ�?) 
                Weapon_Hand.transform.GetChild(0).SetParent(Weapon_Back);
                Weapon_Back.transform.GetChild(0).localPosition = Vector3.zero;
                Weapon_Back.transform.GetChild(0).localRotation = Quaternion.identity;
                //Skill_Range ��Ȱ��ȭ
                Skill_Range.SetActive(false);
                break;
        }
    }
    private void Awake()
    {
        Manager_SceneChange.Inst.player = this; //�� ��ȯ�� �÷��̾��� ��ġ ����
        ChangeMode(Player_Mode.Unbattle);
    }
}
