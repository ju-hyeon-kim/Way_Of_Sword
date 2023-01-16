using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_Data : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this); // 씬전환 시 파괴되지 않음
    }
}
