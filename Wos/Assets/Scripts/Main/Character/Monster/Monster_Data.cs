using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster_Data", menuName = "ScriptableObjects/Monster_Data", order = 1)]
public class Monster_Data : ScriptableObject
{
    public float Arange;
    public float Aspeed;
    public float Mspeed;
    public float MaxHp;
    public float Ap;
    public float Xp;
}
