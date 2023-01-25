using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Guild : MonoBehaviour
{
    public Transform[] Guide_Tartgets;

    private void Start()
    {
        Manager_Quest.Inst.Guide_Tartgets = Guide_Tartgets;
    }
}
