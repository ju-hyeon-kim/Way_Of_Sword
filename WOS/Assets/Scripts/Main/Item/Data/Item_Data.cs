using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item_Data : ScriptableObject
{
    public Sprite Image;
    public string Name;
    public Item.Type ItemType;
    public int Price; // Xp는 경험치 수치
}
