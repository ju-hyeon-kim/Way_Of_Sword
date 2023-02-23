using System;
using UnityEngine;

public enum Mode
{
    NONE, UNBATTLE, BATTLE, DEAD
}

public class Player : Player_Battle //�������, Npc��ȣ�ۿ�, ����
{
    #region ��ӱ���
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
    public Transform[] Parents_of_Weapon; // �� = 0, �� = 1
    public Transform CamTarget_Main;
    public Transform myWeapon;
    public RuntimeAnimatorController[] AnimSet; // 0=Unbattle 1=Battle
    public Mode nowMode = Mode.NONE;
    public Player_Dead Player_Dead;

    public void Change_Mode(Mode mode) // false(0) = ���Ʋ���, true(1) = ��Ʋ���
    {
        nowMode = mode;

        switch (nowMode)
        {
            case Mode.UNBATTLE:
                UnBattle_Or_Battle_Setting(false);
                break;
            case Mode.BATTLE:
                UnBattle_Or_Battle_Setting(true);
                break;
            case Mode.DEAD:
                ControlPossible = false;
                myAnim.SetTrigger("Dead");
                Player_Dead.gameObject.SetActive(true);
                Player_Dead.OnDead();
                break;
        }

    }

    void UnBattle_Or_Battle_Setting(bool b)
    {
        myWeapon.SetParent(Parents_of_Weapon[Convert.ToInt32(b)]);
        myWeapon.localPosition = Vector3.zero;
        myWeapon.localRotation = Quaternion.identity;
        DropRange.gameObject.SetActive(b);
        myAnim.runtimeAnimatorController = AnimSet[Convert.ToInt32(b)];
    }

    public override void MovRotEnd_NpcEvent()
    {
        if (isMovEnd && isRotEnd)
        {
            ControlPossible = false; // �÷��̾��� ���� ����
            myTarget.GetComponent<Npc>().Reaction(this.gameObject);
            isNpc = false;
            isMovEnd = false;
            isRotEnd = false;
        }
    }
}