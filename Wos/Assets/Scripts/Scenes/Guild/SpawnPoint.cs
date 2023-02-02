using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    public string myPlace;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            if (Manager_SceneChange.Inst.Before_Place == myPlace)
            {
                Dont_Destroy_Data.Inst.Player.position = transform.position;
            }
        }
        else
        {
            Transform player = Dont_Destroy_Data.Inst.Player;
            player.GetComponent<Player_Movement>().Stop_Movement();
            player.position = transform.position;
            player.rotation = this.transform.rotation;
            Manager_SceneChange.Inst.Before_Place = myPlace;
        }
    }
}
