using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Point : MonoBehaviour
{
    public string myDestination; // 인스펙터에서 목적지에 해당하는 씬 설정

    Map_Window Map_Window;


    private void Start()
    {
        Map_Window = Dont_Destroy_Data.Inst.Map_Window;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.
        switch(myDestination)
        {
            case "Dungeon":
                Time.timeScale = 0.0f;
                other.GetComponent<Player_Movement>().Stop_Movement();
                Map_Window.NowQuest_Check();
                Map_Window.gameObject.SetActive(true);
                break;
            case "Village":
                //길드와 포레스트 구분 필요
                Manager_SceneChange.Inst.ChangeScene(myDestination);
                break;
            case "Guild":
                Manager_SceneChange.Inst.ChangeScene(myDestination);
                break;
        }
    }
}
