using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill_Data", menuName = "ScriptableObjects/Skill_Data", order = 1)]
public class Skill_Data : ScriptableObject
{
    public string Name;
    [Multiline]
    public string Explanation;
    public float Range;
    public GameObject Effect;
    public SkillPoint SkillPoint;
}
