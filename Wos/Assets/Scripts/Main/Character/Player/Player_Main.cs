using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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
    public Transform myWeapon;
    public NpcTalk_Window NpcTalk_Window;
    public AnimatorController[] AnimSet; // 0=Unbattle 1=Battle

    public void Change_Mode(Player_Mode pm)
    {
        if(NowMode != pm)
        {
            NowMode = pm;
            switch (pm)
            {
                case Player_Mode.Unbattle:
                    myWeapon.SetParent(Weapon_Back);
                    myWeapon.localPosition = Vector3.zero;
                    myWeapon.localRotation = Quaternion.identity;
                    //Skill_Range 비활성화
                    Skill_Range.SetActive(false);
                    //DropZone 비활성화
                    DropZone.SetActive(false);

                    myAnim.runtimeAnimatorController = AnimSet[0];
                    break;
                case Player_Mode.Battle:
                    myWeapon.SetParent(Weapon_Hand);
                    myWeapon.localPosition = Vector3.zero;
                    myWeapon.localRotation = Quaternion.identity;
                    DropZone.SetActive(true);
                    myAnim.runtimeAnimatorController = AnimSet[1];
                    break;
            }
        }
    }
}
