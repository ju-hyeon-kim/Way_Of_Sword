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
    public List<int> ItemType = new List<int>(); // 아이템의 타입 -> 어떤 탭의 인벤토리인가?
    public List<int> ItemSlot = new List<int>(); // 슬롯의번호(슬롯의위치)
    public List<int> ItemID = new List<int>(); // 아이템ID(어떤아이템인지)
    public List<int> ItemQuantity = new List<int>(); // 아이템수량
}
