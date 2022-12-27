using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_Icon : MonoBehaviour
{
    public Transform myTarget;

    bool isPlayer = false;

    void Start()
    {
        if (myTarget.parent.name == "Player") // 플레이어의 아이콘일 경우
        {
            isPlayer = true;
        }
    }

    void Update()
    {
        /*if(myTarget != null)
        {
            Vector3 pos = Camera.allCameras[1].WorldToViewportPoint(myTarget.position);
            transform.localPosition = pos;
        }*/

        if(isPlayer) 
        {
            Vector3 dir = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            dir.y = 0;
            dir.Normalize();
            right.y = 0;
            right.Normalize();
            float rot = Vector3.Angle(myTarget.forward, dir);
            if(Vector3.Dot(myTarget.forward, right) > 0)
            {
                rot = -rot;
            }
            Vector3 Rot = new Vector3(0, 0, rot - 90);
            transform.rotation = Quaternion.Euler(Rot);
        }
    }
}
