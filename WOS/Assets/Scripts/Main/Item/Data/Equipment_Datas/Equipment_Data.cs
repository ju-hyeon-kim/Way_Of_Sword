using UnityEngine;

public class Equipment_Data : Item_Data
{
    [Header("-----Equipment_Data-----")]
    public int Strengthen;
    public EquipmentType EquipnetType;
    public string EquipnetType_Text;
    [TextArea]
    public string Explanation;
}
