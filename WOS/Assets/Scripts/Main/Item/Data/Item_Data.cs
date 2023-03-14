using UnityEngine;

public class Item_Data : ScriptableObject
{
    [Header("-----Item_Data-----")]
    public string Name;
    public int ID;
    public ItemType ItemType;
    public int BuyPrice; // 아이템은 수량(1로 고정), Xp는 경험치 수치, Gold는 금액
    public int SellPrice;
}
