using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest_Data", menuName = "ScriptableObjects/Quest_Data", order = 1)]
public class Quest_Data : ScriptableObject
{
    public int Quest_Number;
    public string Name;
    public string Content;
    public bool isSuccess; // 완료여부
    public List<Item_Data> Reward;
}

[CreateAssetMenu(fileName = "QuestReward_Data", menuName = "ScriptableObjects/QuestReward_Data", order = 1)]
public class QuestReward_Data : ScriptableObject
{
    public Reward_Type Reward_Type;
    public int Quantity; // 완료여부
}

public enum Reward_Type
{
    Item, Money, Xp
}
