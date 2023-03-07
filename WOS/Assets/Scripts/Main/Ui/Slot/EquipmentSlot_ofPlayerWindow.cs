using UnityEngine;

public class EquipmentSlot_ofPlayerWindow : Item_Slot
{
    [Header("-----EquipmentSlot_ofPlayerWindow-----")]
    public EquipmentType EquipmentType_slot;

    public override bool isSame_EquipnemtType()
    {
        Equipment_Data EquipmentData = myItem.myData as Equipment_Data;
        bool b = false;
        if (EquipmentType_slot == EquipmentData.EquipnetType)
        {
            b = true;
        }
        return b;
    }
}
