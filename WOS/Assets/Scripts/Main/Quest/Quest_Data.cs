using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest_Data", menuName = "ScriptableObjects/Quest_Data", order = 1)]
public class Quest_Data : ScriptableObject
{
    public int Quest_Number;
    public string Name;
    [Multiline]
    public string Explanation;
    public List<Item_Data> Reward;
}
