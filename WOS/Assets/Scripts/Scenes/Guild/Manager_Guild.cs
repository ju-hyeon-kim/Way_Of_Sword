using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Guild : Manager_Place
{
    public Transform SpawnPoint_Player;

    private void Awake()
    {
        Play_Starter.Inst.Start_Call(this.transform); // Play_Starter가 없다면 Play_Starter 생성 => Village씬에 처음 왔을 때
    }

    private void Start()
    {
        //Bgm
        Manager_Sound.Inst.BgmSource.OnPlay(3);

        Dont_Destroy_Data.Inst.Manager_Quest.Guide_Targets = Guide_Tartgets;

        Dont_Destroy_Data.Inst.Player.position = SpawnPoint_Player.position;
        Dont_Destroy_Data.Inst.Player.rotation = SpawnPoint_Player.rotation;

        Manager_SceneChange.Inst.Before_Place = SceneManager.GetActiveScene().name;
    }
}
