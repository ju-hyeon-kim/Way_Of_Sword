using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obe_Data", menuName = "ScriptableObjects/Obe_Data", order = 1)]
public class Obe_Data : Item_Data
{
    public int Strengthen;
    public string Obe_Skill;
    [TextArea]
    public string Skill_Explanation;

    public Sprite Skill_Sprite;
    public Skill_Data Skill_Data;
}
