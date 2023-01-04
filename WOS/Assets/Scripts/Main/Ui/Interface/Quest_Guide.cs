using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Guide : MonoBehaviour
{
    public Transform Target;
    public Transform Player;
    public Transform MiniMap_Camera;

    void Update()
    {
        Vector3 dir = Target.position - Player.position;
        dir.y = 0;
        dir.Normalize();    

        float Angle = Vector3.Angle(MiniMap_Camera.transform.up, dir);

        float rotDir = 1.0f; // 1 or -1 => 왼쪽으로 돌지 오른쪽으로 돌지 구분
        if (Vector3.Dot(MiniMap_Camera.transform.right, dir) > 0.0f) 
        {
            rotDir = -rotDir;
        }

        transform.rotation = Quaternion.Euler(0, 0, Angle * rotDir);
    }
}
