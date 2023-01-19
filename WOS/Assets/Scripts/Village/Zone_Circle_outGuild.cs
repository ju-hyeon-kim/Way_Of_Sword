using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Circle_outGuild : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Manager_SceneChange.inst.ChangeScene("Guild");
    }
}
