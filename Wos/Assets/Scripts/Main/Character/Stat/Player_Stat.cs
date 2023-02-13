using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Player_Stat : Character_Stat
{
    public ParticleSystem LevelUp_Eff;
    public GameObject LevelUp_Event;
    public Status Status_Tap;

    //바뀌는 능력치
    int _Level = 1;
    float _Mspeed = 3.0f;
    float _Ap = 10.0f;
    float _Dp = 10.0f;
    float _MaxHp = 100.0f;
    float _CurHp = 100.0f;
    float _MaxMp = 100.0f;
    float _CurMp = 100.0f;
    float _MaxXp = 100.0f;
    float _CurXp = 0.0f;

    //고정된 능력치
    float _Arange = 3.0f;
    float _Aspeed = 3.0f;

    #region 프로퍼티
    //바뀌는 능력치
    public int Level
    {
        get { return _Level; }
        set { _Level = value; }
    }

    public float Mspeed
    {
        get { return _Mspeed; }
        set { _Mspeed = value; }
    }

    public float Ap
    {
        get { return _Ap; }
        set { _Ap = value; }
    }

    public float Dp
    {
        get { return _Dp; }
        set { _Dp = value; }
    }

    public float MaxHp
    {
        get { return _MaxHp; }
        set { _MaxHp = value; }
    }

    public float CurHp
    {
        get { return _CurHp; }
        set { _CurHp = value; }
    }

    public float MaxMp
    {
        get { return _MaxMp; }
        set { _MaxMp = value; }
    }

    public float CurMp
    {
        get { return _CurMp; }
        set { _CurMp = value; }
    }
    public float MaxXp
    {
        get { return _MaxXp; }
        set { _MaxXp = value; }
    }

    public float CurXp
    {
        get { return _CurXp; }
        set { _CurXp = value; }
    }

    // 고정된 능력치
    public float Arange
    {
        get { return _Arange; }
    }

    public float Aspeed
    {
        get { return _Aspeed; }
    }
    #endregion

    #region 오버라이드
    public override float ap() { return _Ap; }

    public override float dp() { return _Dp; }

    public override float arange() { return _Arange; }

    public override float mspeed() { return _Mspeed; }

    public override float maxhp() { return _MaxHp; }

    public override float maxmp() { return _MaxMp; }

    public override float curmp() {  return _CurMp; }

    public override float aspeed() { return _Aspeed; }
    #endregion

    public void Level_Up()
    {
        LevelUp_Eff.Play();
        LevelUp_Event.SetActive(true);

        ++Level;
        Mspeed += 0.1f;
        Ap += 5f;
        Dp += 5f;
        MaxHp += 30.0f;
        MaxMp += 30.0f;
        MaxXp += 50.0f;

        Status_Tap.Update_Status(this);

    }
}