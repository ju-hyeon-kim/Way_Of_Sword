using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCam_Controller : MonoBehaviour
{
    public Transform Cam_Target;
    public Transform[] Icons;

    Vector3 myDir = Vector3.zero;
    float myDist = 0.0f;
    float minZoom = 40.0f;
    float maxZoom = 80.0f;

    void Start()
    {
        myDir = transform.position - Cam_Target.position;

        myDist = myDir.magnitude;
        myDir.Normalize();
    }

    void Update()
    {
        transform.position = Cam_Target.position + myDir * myDist;
    }

    public void ZoomIn()
    {
        myDist -= 5.0f;
        myDist = Mathf.Clamp(myDist, minZoom, maxZoom); // ÁÜ Á¦ÇÑ°ª
        if (myDist > minZoom + 1 && myDist < maxZoom - 1)
        {
            for(int i = 0; i < Icons.Length; i++)
            {
                Icons[i].localScale = new Vector3(Icons[i].localScale.x * 0.9f, Icons[i].localScale.y * 0.9f, 1);
            }
        }
        
    }

    public void ZoomOut()
    {
        myDist += 5.0f;
        myDist = Mathf.Clamp(myDist, minZoom, maxZoom); // ÁÜ Á¦ÇÑ°ª
        if (myDist > minZoom + 1 && myDist < maxZoom - 1)
        {
            for (int i = 0; i < Icons.Length; i++)
            {
                Icons[i].localScale = new Vector3(Icons[i].localScale.x * 1.1f, Icons[i].localScale.y * 1.1f, 1);
            }
        }
    }
}
