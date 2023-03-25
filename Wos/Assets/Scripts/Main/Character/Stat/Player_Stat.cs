using System.Data;
using UnityEngine;

public class Player_Stat : Character_Stat
{
    public PlayerStat_Data StatData;
    public ParticleSystem LevelUp_Eff;
    public GameObject LevelUp_Event;

    public Status_Tap Status_Tap;
    public Equipment_Tap Equipment_Tap;
    public Skill_Set Skill_Set;

    

    //바뀌는 능력치
    int _Level = 1;

    float _PlayerMspeed = 3.0f;
    float _AddMspeed = 0.0f;

    float _CurHp = 0;
    float _CurMp = 0;
    float _CurXp = 0;

    //고정된 능력치
    float _Aspeed = 3.0f;

    private void Start()
    {
        Status_Tap.Update_Status(); // Status_Tap 초기 세팅
        CurHp = MaxHp;
        CurMp = MaxMp;
    }

    #region 프로퍼티
    //Level
    public int Level
    {
        get { return _Level; }
        set 
        {
            _Level = value;
            //UI연동: PlayerInterface, StatusTap
            Status_Tap.Update_Status();
        }
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
        get { return StatData.Ap[_Level]; }
    }
    public float AddAp 
    { 
        get { return Equipment_Tap.AddAp(); }
    }

    //Dp
    public float TotalDp { get { return PlayerDp + AddDp; } }
    public float PlayerDp
    {
        get { return StatData.Dp[_Level]; }
    }
    public float AddDp
    {
        get { return Equipment_Tap.AddDp(); }
    }

    //Hp
    public float MaxHp { get { return PlayerHp + AddHp; } }
    public float PlayerHp
    {
        get { return StatData.Hp[_Level]; }
    }
    public float AddHp // 장착한 아이템에서 가져오는 Hp
    {
        get { return 0; } 
    }
    public float CurHp
    {
        get { return _CurHp; }
        set { _CurHp = value; }
    }

    //Mp
    public float MaxMp { get { return PlayerMp + AddMp; } }
    public float PlayerMp
    {
        get { return StatData.Mp[_Level]; }
    }
    public float AddMp // 장착한 아이템에서 가져오는 Mp
    {
        get { return 0; } 
    }
    public float CurMp
    {
        get { return _CurMp; }
        set { _CurMp = value; }
    }

    //Xp
    public float MaxXp
    {
        get { return StatData.Xp[_Level]; }
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
}