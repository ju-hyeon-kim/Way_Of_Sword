using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster_Data", menuName = "ScriptableObjects/Monster_Data", order = 1)]
public class Monster_Data : ScriptableObject
{
    public string Name;
    public float MaxHp;
    public float Ap; //AttackPoint
    public float Ad; //AttackDelay
    public float Ar; //AttackRange
}
