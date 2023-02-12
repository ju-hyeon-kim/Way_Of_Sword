using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : Character_Stat
{

    float _Ap = 10.0f;
    float _Arange = 2.0f;
    float _Mspeed = 3.0f;

    public override float Ap()
    {
        return _Ap;
    }

    public override float Arange()
    {
        return _Arange;
    }

    public override float Mspeed()
    {
        return _Mspeed;
    }
}
