using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCam_Controller : MonoBehaviour
{
    public Transform Cam_Target;

    Vector3 myDir = Vector3.zero;
    float myDist = 0.0f;

    void Start()
    {
        myDir = transform.position - Cam_Target.position;

        myDist = myDir.magnitude;
        myDir.Normalize();
    }

    void Update()
    {
        transform.position = Cam_Target.position + myDir * myDist;
        myDist = Mathf.Clamp(myDist, 5.0f, 28.0f);
    }

    public void ZoomIn()
    {
        myDist -= 2.0f;
    }

    public void ZoomOut()
    {
        myDist += 2.0f;
    }
}
