using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon_2D : Item2D_isStrengthen
{
    [Header("-----Weapon_2D-----")]
    public Transform[] Equipped_Obes = new Transform[4];
    public Transform myWeapon_3D;

    public override void Reset_myDataWindow()
    {
        myData_Window = Dont_Destroy_Data.Inst.ItemData_WindowSet.WeaponData_Window;
    }
}
