using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Village : MonoBehaviour
{
    public Transform[] Guide_Tartgets = new Transform[10];

    private void Awake()
    {
        Play_Starter.Inst.Start_Call(); // Play_Starter�� ���ٸ� Play_Starter ���� => Village���� ó�� ���� ��
    }

    private void Start()
    {
        Manager_Quest.Inst.Guide_Tartgets = Guide_Tartgets;

    }
}
