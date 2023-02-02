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
    #region 상속구조
    /*
     * Character_Property
     * ->
     * Character_Movement, IBattle
     * ->
     * Player_Movement
     * ->
     * Player_Main
     */
    #endregion

    public Player_Mode NowMode = Player_Mode.None;

    public GameObject Skill_Range;
    public Transform Weapon_Back;
    public Transform Cam_Target;
    public GameObject DropZone;
    
    public NpcTalk_Window NpcTalk_Window;

    public void Change_Mode(Player_Mode pm)
    {
        if(NowMode != pm)
        {
            NowMode = pm;
            switch (pm)
            {
                case Player_Mode.Unbattle: // 언배틀 모드일 경우
                                           //무기의 위치는 손 -> 등 뒤로 이동 (예외처리?: 만약 이미 무기가 등 뒤에 있다면?) 
                    Weapon_Hand.GetChild(0).SetParent(Weapon_Back);
                    Weapon_Back.GetChild(0).localPosition = Vector3.zero;
                    Weapon_Back.GetChild(0).localRotation = Quaternion.identity;
                    //Skill_Range 비활성화
                    Skill_Range.SetActive(false);
                    //DropZone 비활성화
                    DropZone.SetActive(false);
                    break;
                case Player_Mode.Battle:
                    Weapon_Back.GetChild(0).SetParent(Weapon_Hand);
                    Weapon_Hand.GetChild(1).localPosition = Vector3.zero;
                    Weapon_Hand.GetChild(1).localRotation = Quaternion.identity;
                    DropZone.SetActive(true);
                    break;
            }
        }
    }
}
