using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "ScriptableObjects/Item_Data", order = 1)]
public class Item_Data : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public string Type;
    public float AP;
    public float Price;
    public string Explanation_Text;
    public Item.Type ItemType;
}
