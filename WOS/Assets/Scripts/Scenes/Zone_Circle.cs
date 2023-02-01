using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Circle : MonoBehaviour
{
    public string NextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        //플레이어보다 드랍존이 먼저 닿는다.
        //other.GetComponent<Player_Movement>().Stop_Movement();
        Manager_SceneChange.Inst.ChangeScene(NextSceneName);
    }
}
