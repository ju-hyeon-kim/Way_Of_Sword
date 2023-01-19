using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Village : MonoBehaviour
{
    public Transform[] Tartgets_inVillage = new Transform[10];

    private void Awake()
    {
        Play_Starter.Inst.Call(); // Play_Starter가 없다면 Play_Starter 생성 => Village씬에 처음 왔을 때
    }

    private void Start()
    {
        Manager_Quest.Inst.Guide_Tartgets = Tartgets_inVillage;
    }
}
