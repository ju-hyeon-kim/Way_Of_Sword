using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Village : MonoBehaviour
{
    public GameObject Player;
    public MainCam_Controller MainCam_Controller;
    public MiniMapCam_Controller MiniMapCam_Controller;

    private void Awake()
    {
        //플레이어 소환
        GameObject P = Instantiate(Player, transform.parent);
        P.transform.position = transform.position;

        Player_Main pm = P.GetComponent<Player_Main>();
        MainCam_Controller.Cam_Target = pm.Cam_Target;
        MiniMapCam_Controller.Cam_Target = pm.Cam_Target;
    }
}
