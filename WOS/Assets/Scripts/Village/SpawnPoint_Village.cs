using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Village : MonoBehaviour
{
    public GameObject Player;
    public MainCam_Controller MainCam_Controller;

    private void Awake()
    {
        //�÷��̾� ��ȯ
        Instantiate(Player, transform.parent);
        Player.transform.position = transform.position;


    }
}
