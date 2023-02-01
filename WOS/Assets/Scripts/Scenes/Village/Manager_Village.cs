using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Village : MonoBehaviour
{
    public Transform[] Guide_Tartgets;
    public Transform[] Minimap_Icons;

    private void Awake()
    {
        Play_Starter.Inst.Start_Call(); // Play_Starter�� ���ٸ� Play_Starter ���� => Village���� ó�� ���� ��
    }

    private void Start()
    {
        Dont_Destroy_Data.Inst.Manager_Quest.Guide_Tartgets = Guide_Tartgets;
        Dont_Destroy_Data.Inst.Player.GetComponent<Player_Main>().Change_Mode(Player_Mode.Unbattle);
        Manager_SceneChange.Inst.MiniMapCam_Controller.MiniMap_Icons = Minimap_Icons;
    }
}
