using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Player_Battle //장비착용, Npc상호작용
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

    [Header("-----Player-----")]
    public Transform[] Parents_of_Weapon; // 등 = 0, 손 = 1
    public Transform CamTarget_Main;
    public Transform myWeapon;
    public AnimatorController[] AnimSet; // 0=Unbattle 1=Battle

    GameObject myNpc;

    public void Change_Mode(bool b) // false(0) = 언배틀모드, true(1) = 배틀모드
    {
        myWeapon.SetParent(Parents_of_Weapon[Convert.ToInt32(b)]);
        myWeapon.localPosition = Vector3.zero;
        myWeapon.localRotation = Quaternion.identity;
        DropRange.gameObject.SetActive(b);
        myAnim.runtimeAnimatorController = AnimSet[Convert.ToInt32(b)];
        if(b == false)
        {
            //SkillRange.gameObject.SetActive(false);
        }
    }

    public override void MoveToNpc(RaycastHit hit)
    {
        myNpc = hit.collider.gameObject;
        base.MoveToPos(hit.point);
    }

    public void NpcEvent()
    {
        /*if (move_end && rot_end)
        {
            isEvent = true; // 플레이어의 조작 제한
            myNpc.GetComponent<Npc>().Reaction(gameObject);
            move_end = false;
            rot_end = false;
        }*/
    }

    public override void P_MoveEnd_NpcAction()
    {
        /*if (isNpc)
        {
            move_end = true;
            NpcEvent();
        }*/
    }

    public override void P_RotEnd_NpcAction()
    {
        /*if (isNpc)
        {
            rot_end = true;
            NpcEvent();
        }*/
    }
}
