using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Item
{
    public enum Type
    {
        Equipment, Obe, Expendables, Ingredient
    }

    public enum EquipmentType // 장비품이 아닐경우 None
    {
        None, Weapon, Necklace, Bracelet, Ring, Helmet, Top, Pants, Boots, 
    }
}
