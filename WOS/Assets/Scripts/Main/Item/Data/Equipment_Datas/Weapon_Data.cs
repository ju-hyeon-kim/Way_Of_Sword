using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_Data", menuName = "ScriptableObjects/Weapon_Data", order = 1)]
public class Weapon_Data : Equipment_Data
{
    [Header("-----Weapon_Data-----")]
    public Obe_Data[] Equipped_Obes = new Obe_Data[4];
}
