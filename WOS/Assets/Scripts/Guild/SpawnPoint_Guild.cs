using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Guild : MonoBehaviour
{
    private void Start()
    {
        Manager_SceneChange.inst.player.transform.position = transform.position;
    }
}