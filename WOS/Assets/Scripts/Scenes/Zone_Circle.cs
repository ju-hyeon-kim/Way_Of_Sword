using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_Circle : MonoBehaviour
{
    public string NextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player_Movement>().Stop_Movement();
        Manager_SceneChange.Inst.ChangeScene(NextSceneName);
    }
}
