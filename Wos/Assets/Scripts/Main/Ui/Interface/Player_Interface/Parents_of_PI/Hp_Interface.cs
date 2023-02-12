using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Interface : Mp_Interface
{
    [Header("-----Hp_Iterface-----")]
    public Hp_Set Hp_Set;

    public void OnDamage(float dmg)
    {
        Hp_Set.OnDamage(dmg);
    }
}
