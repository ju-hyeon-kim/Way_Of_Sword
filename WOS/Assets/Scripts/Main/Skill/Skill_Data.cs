using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill_Data", menuName = "ScriptableObjects/Skill_Data", order = 1)]
public class Skill_Data : ScriptableObject
{
    public Sprite Image;
    public string Name;
    [Multiline]
    public string Skill_Explanation;
}
