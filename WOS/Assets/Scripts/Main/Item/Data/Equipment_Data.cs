using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_Data", menuName = "ScriptableObjects/Weapon_Data", order = 1)]
public class Equipment_Data : Item_Data
{
    public int Strengthen;
    public Item.EquipmentType EquipmentType;
    public float AP;
    [TextArea]
    public string Explanation_Text;
    public Obe_Data[] Equipped_Obes = new Obe_Data[4];
}
