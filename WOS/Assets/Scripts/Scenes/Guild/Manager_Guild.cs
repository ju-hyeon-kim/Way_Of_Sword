using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Guild : Manager_Place
{
    public Transform SpawnPoint_Player;

    private void Start()
    {
        Dont_Destroy_Data.Inst.Manager_Quest.Guide_Tartgets = Guide_Tartgets;

        Dont_Destroy_Data.Inst.Player.position = SpawnPoint_Player.position;
        Dont_Destroy_Data.Inst.Player.rotation = SpawnPoint_Player.rotation;

        Manager_SceneChange.Inst.Before_Place = SceneManager.GetActiveScene().name;
    }
}
