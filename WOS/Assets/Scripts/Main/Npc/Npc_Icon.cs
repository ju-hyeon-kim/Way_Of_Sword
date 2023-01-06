using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Icon : MonoBehaviour // Vector.back 이 바라보는 방향
{
    private void Update()
    {
        transform.LookAt(Manager_SceneChange.inst.MainCam);
    }
}
