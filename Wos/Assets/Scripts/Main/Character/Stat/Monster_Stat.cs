using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Stat : Character_Stat
{
    public Monster_Data myData;

    public override float ap()
    {
        return myData.Ap;
    }

    public override float arange()
    {
        return myData.Arange;
    }

    public override float mspeed()
    {
        return myData.Mspeed;
    }

    public override float maxhp()
    {
        return myData.MaxHp;
    }

    public override float aspeed()
    {
        return myData.Aspeed;
    }

    public override float xp()
    {
        return myData.Xp;
    }
}
