using UnityEngine;

public class Player_Stat : Character_Stat
{
    public ParticleSystem LevelUp_Eff;
    public GameObject LevelUp_Event;

    public Status_Tap Status_Tap;
    public Equipment_Tap Equipment_Tap;
    public Skill_Set Skill_Set;

    private void Start()
    {
        Status_Tap.Update_Status(); // Status_Tap 초기 세팅
    }

    //바뀌는 능력치

    //Level
    int _Level = 1;

    //Mspeed
    float _PlayerMspeed = 3.0f;
    float _AddMspeed = 0.0f;

    //Ap
    float _PlayerAp = 10.0f;

    //Dp
    float _PlayerDp = 10.0f;

    //Hp
    float _PlayerHp = 100.0f;
    float _AddHp = 0.0f;
    float _CurHp = 100.0f;

    //Mp
    float _PlayerMp = 100.0f;
    float _AddMp = 0.0f;
    float _CurMp = 100.0f;

    //Xp
    float _MaxXp = 100.0f; // 초기값은 100
    float _CurXp = 0.0f;

    //고정된 능력치
    float _Aspeed = 3.0f;

    #region 프로퍼티
    //Level
    public int Level
    {
        get { return _Level; }
        set { _Level = value; }
    }

    //Mspeed
    public float TotalMspeed { get { return _PlayerMspeed + _AddMspeed; } }
    public float PlayerMspeed
    {
        get { return _PlayerMspeed; }
        set { _PlayerMspeed = value; }
    }
    public float AddMspeed
    {
        get { return _AddMspeed; }
        set { _AddMspeed = value; }
    }

    //Ap
    public float TotalAp_Attack { get { return PlayerAp + AddAp; } }
    public float PlayerAp
    {
        get { return _PlayerAp; }
        set { _PlayerAp = value; }
    }
    public float AddAp 
    { 
        get { return Equipment_Tap.AddAp(); }
    }

    //Dp
    public float TotalDp { get { return _PlayerDp + AddDp; } }
    public float PlayerDp
    {
        get { return _PlayerDp; }
        set { _PlayerDp = value; }
    }
    public float AddDp
    {
        get { return Equipment_Tap.AddAp(); }
    }

    //Hp
    public float MaxHp { get { return _PlayerHp + _AddHp; } }
    public float PlayerHp
    {
        get { return _PlayerHp; }
        set { _PlayerHp = value; }
    }
    public float AddHp
    {
        get { return _AddHp; }
        set { _AddHp = value; }
    }
    public float CurHp
    {
        get { return _CurHp; }
        set { _CurHp = value; }
    }

    //Mp
    public float MaxMp { get { return _PlayerMp + _AddMp; } }
    public float PlayerMp
    {
        get { return _PlayerMp; }
        set { _PlayerMp = value; }
    }
    public float AddMp
    {
        get { return _AddMp; }
        set { _AddMp = value; }
    }
    public float CurMp
    {
        get { return _CurMp; }
        set { _CurMp = value; }
    }

    //Xp
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
    public float Aspeed
    {
        get { return _Aspeed; }
    }
    #endregion

    #region 오버라이드
    public override float ap() { return TotalAp_Attack; }

    public override float dp() { return TotalDp; }

    public override float maxhp() { return MaxHp; }

    public override float maxmp() { return MaxMp; }

    public override float mspeed() { return TotalMspeed; }

    public override float curmp() { return _CurMp; }

    public override float aspeed() { return _Aspeed; }
    #endregion

    public void Level_Up()
    {
        LevelUp_Eff.Play();
        LevelUp_Event.SetActive(true);

        ++Level;
        PlayerMspeed += 0.1f;
        PlayerAp += 5f;
        PlayerDp += 5f;
        PlayerHp += 30.0f;
        PlayerMp += 30.0f;
        MaxXp += 50.0f;

        Status_Tap.Update_Status();
    }
}