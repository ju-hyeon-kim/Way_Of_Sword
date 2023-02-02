using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_notVillage : MonoBehaviour
{
    void Start()
    {
        Transform player = Dont_Destroy_Data.Inst.Player;
        player.GetComponent<Player_Movement>().Stop_Movement();
        player.position = transform.position;
        player.rotation = this.transform.rotation;
        Manager_SceneChange.Inst.Before_Place = "Guild";
    }
}
