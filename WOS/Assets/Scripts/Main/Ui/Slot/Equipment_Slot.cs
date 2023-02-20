using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Equipment_Slot : Item_Slot
{
    [Header("-----Equiment_Slot-----")]
    public EquipmentType EquipmentType_slot;

    public override bool isSame_EquipnemtType()
    {
        Equipment_Data EquipmentData = myItem.myData as Equipment_Data;
        bool b = false;
        if(EquipmentType_slot == EquipmentData.EquipnetType)
        {
            b = true;
        }
        return b;
    }
}
