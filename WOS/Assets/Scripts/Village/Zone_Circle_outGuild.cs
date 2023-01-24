using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Circle_outGuild : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player_Movement>().Stop_Movement();
        Manager_SceneChange.Inst.ChangeScene("Guild");
    }
}
