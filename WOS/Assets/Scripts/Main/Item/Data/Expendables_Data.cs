using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Expendables_Data", menuName = "ScriptableObjects/Expendables_Data", order = 1)]
public class Expendables_Data : Item_Data
{
    public string AbillityExplanation;
    public float Ap; // AbillityPoint
    [TextArea]
    public string Explanation;
}