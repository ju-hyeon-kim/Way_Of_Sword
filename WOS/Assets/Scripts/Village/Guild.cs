using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guild : MonoBehaviour
{
    public SpawnPoint_Village SpawnPoint_Village;

    private void Start()
    {
        SpawnPoint_Village.Tartgets_inVillage[0] = transform;
    }
}
