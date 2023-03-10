using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Armor_Data", menuName = "ScriptableObjects/Armor_Data", order = 1)]
public class Armor_Data : Equipment_Data
{
    [Header("-----Armor_Data-----")]
    public float Dp;
    public ArmorType ArmorType;
}
