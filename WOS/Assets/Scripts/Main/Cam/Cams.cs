using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cams : MonoBehaviour
{
    private void Awake()  // ����ȯ �� �ı����� ����
    {
        DontDestroyOnLoad(this);
    }
}
