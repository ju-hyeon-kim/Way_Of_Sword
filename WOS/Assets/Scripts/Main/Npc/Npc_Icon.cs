using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_Icon : MonoBehaviour // Vector.back �� �ٶ󺸴� ����
{
    private void Update()
    {
        transform.LookAt(Manager_SceneChange.inst.MainCam);
    }
}
