using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Stat : MonoBehaviour
{
    public Monster_Data myData;

    public float Ap()
    {
        return myData.Ap;
    }

    public float Arange()
    {
        return myData.Arange;
    }

    public float Mspeed()
    {
        return myData.Mspeed;
    }

    public float MaxHp()
    {
        return myData.MaxHp;
    }

    public float Aspeed()
    {
        return myData.Aspeed;
    }

    public float Xp()
    {
        return myData.Xp;
    }
}
