using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Icon : MonoBehaviour
{
    
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }
}
