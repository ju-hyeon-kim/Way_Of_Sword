using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Guild : MonoBehaviour
{
    public Transform[] Guide_Tartgets;

    private void Start()
    {
       Dont_Destroy_Data.Inst.Manager_Quest.Guide_Tartgets = Guide_Tartgets;
    }
}
