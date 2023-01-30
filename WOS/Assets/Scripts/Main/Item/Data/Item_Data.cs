using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Data", menuName = "ScriptableObjects/Item_Data", order = 1)]
public class Item_Data : ScriptableObject
{
    //public Sprite Image;
    public string Name;
    public ItemType ItemType;
    public int Price; // 아이템은 수량(1로 고정), Xp는 경험치 수치, Gold는 금액
}
