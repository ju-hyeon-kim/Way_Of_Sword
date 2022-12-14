using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon_ExclamarionMark : MonoBehaviour
{
    public Transform IconZone;
    Vector3 pos;

    private void Start()
    {
        pos = Camera.main.WorldToScreenPoint(IconZone.position);
        transform.position = pos;
    }
} 