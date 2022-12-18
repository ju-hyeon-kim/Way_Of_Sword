using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Cam : MonoBehaviour
{
    public Transform Cam_Target;
    Vector3 myDir = Vector3.zero;

    private void Start()
    {
        myDir = transform.position - Cam_Target.position;
    }

    private void Update()
    {
        transform.position = Cam_Target.position + myDir;
    }
}
