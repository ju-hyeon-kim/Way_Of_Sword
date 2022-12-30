using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Data", menuName = "ScriptableObjects/Item_Data", order = 1)]
public class Item_Data : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public Item.Type ItemType;
    public Item.EquipmentType EquipmentType;
    public float AP;
    public float Price;
    [TextArea]
    public string Explanation_Text;
}
