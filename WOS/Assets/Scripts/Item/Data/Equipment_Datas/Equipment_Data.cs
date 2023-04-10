using UnityEngine;

public class Equipment_Data : Item_Data
{
    [Header("-----Equipment_Data-----")]
    public EquipmentType EquipmentType;
    public float[] Stat;
    [TextArea]
    public string Explanation;
}
