using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStat_Data", menuName = "ScriptableObjects/PlayerStat_Data", order = 1)]
public class PlayerStat_Data : ScriptableObject
{
    public float[] Ap;
    public float[] Dp;
    public float[] Hp;
    public float[] Mp;
    public float[] Xp;
}
