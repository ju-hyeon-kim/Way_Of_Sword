using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Item
{
    public enum Type
    {
        Equipment, Obe, Expendables, Ingredient
    }

    public enum EquipmentType // ���ǰ�� �ƴҰ�� None
    {
        None, Weapon, Necklace, Bracelet, Ring, Helmet, Top, Pants, Boots, 
    }
}
