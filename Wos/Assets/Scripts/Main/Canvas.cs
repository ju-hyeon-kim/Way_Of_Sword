using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this); // 씬전환 시 파괴되지 않음
    }
}
