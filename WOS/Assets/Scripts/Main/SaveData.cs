using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string QuestName;
    public string Place;
    public int Gold;
    public string Time;
    public int Level;

    //Item
    public List<int> ItemType = new List<int>(); // �������� Ÿ�� -> � ���� �κ��丮�ΰ�?
    public List<int> ItemSlot = new List<int>(); // �����ǹ�ȣ(��������ġ)
    public List<int> ItemID = new List<int>(); // ������ID(�����������)
    public List<int> ItemQuantity = new List<int>(); // �����ۼ���
}
