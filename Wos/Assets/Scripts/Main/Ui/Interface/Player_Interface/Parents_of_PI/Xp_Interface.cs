using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xp_Interface : MonoBehaviour
{
    [Header("-----Xp_Interface-----")]
    public Xp_Set Xp_Set;

    public void Get_Xp(float xp)
    {
        Xp_Set.Get_Xp(xp);
    }
}
