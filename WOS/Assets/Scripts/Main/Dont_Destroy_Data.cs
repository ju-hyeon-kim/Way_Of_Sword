using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_Data : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this); // ����ȯ �� �ı����� ����
    }
}
