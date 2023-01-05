using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cams : MonoBehaviour
{
    private void Awake()  // 씬전환 시 파괴되지 않음
    {
        DontDestroyOnLoad(this);
    }
}
