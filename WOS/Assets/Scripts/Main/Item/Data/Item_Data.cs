using UnityEngine;

public class Item_Data : ScriptableObject
{
    [Header("-----Item_Data-----")]
    public string Name;
    public int ID;
    public ItemType ItemType;
    public int BuyPrice;
    public int SellPrice;
}
