using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Circle_inGuild : MonoBehaviour
{
    private void Awake()
    {
        //Manager_Quest.Inst.Guide_Tartgets[1] = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        Manager_SceneChange.Inst.ChangeScene("Village");
    }
}
