using UnityEngine;

public class Manager_Village : Manager_Place
{
    public Transform[] SpawnPoints_Player; // 0 = ��忡�� ����� 1 = �������� �����
    public Transform[] Minimap_Icons;


    private void Awake()
    {
        Play_Starter.Inst.Start_Call(this.transform); // Play_Starter�� ���ٸ� Play_Starter ����, �ִٸ� ���� ����
    }

    private void Start()
    {
        Dont_Destroy_Data.Inst.Manager_Quest.Guide_Tartgets = Guide_Tartgets;
        Dont_Destroy_Data.Inst.Player.GetComponent<Player>().Change_Mode(Mode.UNBATTLE);
        Manager_SceneChange.Inst.MiniMapCam_Controller.MiniMap_Icons = Minimap_Icons;

        //Spawn Player
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        switch (Manager_SceneChange.Inst.Before_Place)
        {
            case "Guild":
                Dont_Destroy_Data.Inst.Player.position = SpawnPoints_Player[0].position;
                Dont_Destroy_Data.Inst.Player.rotation = SpawnPoints_Player[0].rotation;
                break;
            case "Forest":
                Dont_Destroy_Data.Inst.Player.position = SpawnPoints_Player[1].position;
                Dont_Destroy_Data.Inst.Player.rotation = SpawnPoints_Player[1].rotation;
                break;
        }
    }
}
