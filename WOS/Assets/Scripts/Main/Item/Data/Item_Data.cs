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
    public int Price; // �������� ����(1�� ����), Xp�� ����ġ ��ġ, Gold�� �ݾ�
}
