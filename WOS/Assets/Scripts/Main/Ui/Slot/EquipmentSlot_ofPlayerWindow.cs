using UnityEngine;

public class EquipmentSlot_ofPlayerWindow : Item_Slot
{
    [Header("-----EquipmentSlot_ofPlayerWindow-----")]
    public Status_Tap Status_Tap;

    public virtual void Put_Item(Item_2D item) { }

    public override void isEquipment()
    {
        //스탯창 초기화
        Status_Tap.Update_Status();
    }
}
