using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Forest : MonoBehaviour
{
    void Start()
    {
        Dont_Destroy_Data.Inst.Map_Window.gameObject.SetActive(false);
        Dont_Destroy_Data.Inst.Player.GetComponent<Player_Main>().Change_Mode(Player_Mode.Battle);
        Time.timeScale = 1.0f;
    }
}
