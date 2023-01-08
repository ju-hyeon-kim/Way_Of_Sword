using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Circle_Guild : MonoBehaviour
{
    public MiniMapCam_Controller MiniMapCam_Controller;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 1; i < MiniMapCam_Controller.Icons.Count; i++) // 0��° ���(Player) ���� ���� ����
        {
            MiniMapCam_Controller.Icons.RemoveAt(i);
        }

        Manager_SceneChange.inst.ChangeScene("Guild");
    }
}
