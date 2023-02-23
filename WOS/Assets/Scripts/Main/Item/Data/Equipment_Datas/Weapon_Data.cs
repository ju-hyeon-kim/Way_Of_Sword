using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_Data", menuName = "ScriptableObjects/Weapon_Data", order = 1)]
public class Weapon_Data : Equipment_Data
{
    public float Ap;
    public Obe_Data[] Equipped_Obes = new Obe_Data[4];
}
