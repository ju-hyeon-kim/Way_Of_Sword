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
            case Player_Mode.Unbattle: // 언배틀 모드일 경우
                //무기의 위치는 손 -> 등 뒤로 이동 (예외처리?: 만약 이미 무기가 등 뒤에 있다면?) 
                Weapon_Hand.transform.GetChild(0).SetParent(Weapon_Back);
                Weapon_Back.transform.GetChild(0).localPosition = Vector3.zero;
                Weapon_Back.transform.GetChild(0).localRotation = Quaternion.identity;
                //Skill_Range 비활성화
                Skill_Range.SetActive(false);
                break;
        }
    }
    private void Awake()
    {
        Manager_SceneChange.Inst.player = this; //씬 전환시 플레이어의 위치 설정
        ChangeMode(Player_Mode.Unbattle);
    }
}
