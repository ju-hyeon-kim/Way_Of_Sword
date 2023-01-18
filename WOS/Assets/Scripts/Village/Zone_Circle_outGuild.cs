using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Circle_outGuild : MonoBehaviour
{

    private void Awake()
    {
        Manager_Quest.Inst.Guide_Tartgets[0] = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        Manager_SceneChange.inst.ChangeScene("Guild");
    }
}
