using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
    //바뀌는 능력치
    int Level = 1;
    float Speed = 3.0f;
    float Ap = 10.0f;
    float Dp = 10.0f;
    float maxHp = 100.0f;
    float maxMp = 100.0f;

    //고정된 능력치

    public float MaxHp()
    {
        return maxHp;
    }
}
