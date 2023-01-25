using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Point : MonoBehaviour
{
    void Start()
    {
        Dont_Destroy_Data.Inst.Player.position = transform.position;
    }
}
