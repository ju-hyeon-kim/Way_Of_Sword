using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Guild : MonoBehaviour
{
    private void Start()
    {
        Dont_Destroy_Data.Inst.Player.position = transform.position;
        //Dont_Destroy_Data.Inst.Player.rotation = Quaternion.Euler(transform.forward);
        Dont_Destroy_Data.Inst.Player.rotation = this.transform.localRotation;
        Manager_SceneChange.Inst.Before_Place = "Guild";
    }
}