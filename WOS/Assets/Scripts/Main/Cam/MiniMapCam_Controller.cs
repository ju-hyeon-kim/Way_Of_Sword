using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCam_Controller : MonoBehaviour
{
    public Transform Cam_Target;

    Vector3 myDir = Vector3.zero;

    void Start()
    {
        myDir = transform.position - Cam_Target.position;
    }

    void Update()
    {
        transform.position = Cam_Target.position + myDir;
    }
}
