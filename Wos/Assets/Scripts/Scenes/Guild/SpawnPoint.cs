using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour // test중 원래 포지션.z 값 = 8
{
    public string myPlace;

    public void PlayerPosSetting()
    //void Start()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            if (Manager_SceneChange.Inst.Before_Place == myPlace)
            {
                Dont_Destroy_Data.Inst.Player.position = this.transform.position;
            }
        }
        else
        {
            Transform player = Dont_Destroy_Data.Inst.Player;
            player.GetComponent<Player_Movement>().Stop_Movement();
            player.position = this.transform.position;
            player.rotation = this.transform.rotation;
            Manager_SceneChange.Inst.Before_Place = myPlace;
        }
    }
}
