using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Chicle_Guild : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Manager_SceneChange.inst.ChangeScene("Guild");
    }
}
