using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Guild : MonoBehaviour
{
    private void Start()
    {
        Manager_SceneChange.Inst.player.transform.position = transform.position;
        Manager_SceneChange.Inst.Before_Place = "Guild";
    }
}