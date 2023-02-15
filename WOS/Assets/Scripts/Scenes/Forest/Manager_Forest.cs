using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class Manager_Forest : Manager_Place
{
    public GameObject Beatle;
    public GameObject BeatleKing;
    public Transform SpawnPoint_Player;
    public Transform SpawnPoint_Beatle;
    public Transform SpawnPoint_BeatleKing;
    public Transform[] Beatle_Zone; // 비틀의 로밍 제한 구역
    public GameObject BZ_MagicCicle;

    int NomalMonster_Count = 5; // 비틀 생성 갯수

    private void Awake()
    {
        Play_Starter.Inst.Start_Call(this.transform);
    }

    void Start()
    {
        for (int i = 0; i < NomalMonster_Count; i++)
        {
            //몬스터 소환
            GameObject Beatle_Obj = Instantiate(Beatle, SpawnPoint_Beatle);
            //랜덤한 위치로 이동시켜줌 (Beatle_Zone안에서)
            RandomPos_Monster(Beatle_Obj.transform);

            //소환한 몬스터에게 로밍구역 값을 전달
            Beatle_Obj.GetComponent<NormalMonster>().Roaming_Zone = Beatle_Zone;
            //되살아 날때 RandomPos_Monster를 통해 새로운 위치를 할당받기위해서
            Beatle_Obj.GetComponent<NormalMonster>().myManager = this.transform;
        }

        //Spawn Player
        Transform player = Dont_Destroy_Data.Inst.Player;
        player.GetComponent<Player_Movement>().Stop_Movement();
        player.position = SpawnPoint_Player.position;
        player.rotation = SpawnPoint_Player.rotation;
        Manager_SceneChange.Inst.Before_Place = SceneManager.GetActiveScene().name;

        Dont_Destroy_Data.Inst.myPlaceManager = this.transform;
        Dont_Destroy_Data.Inst.Manager_Quest.Guide_Tartgets = Guide_Tartgets;
        Dont_Destroy_Data.Inst.Player.GetComponent<Player>().Change_Mode(Mode.BATTLE);
        Dont_Destroy_Data.Inst.Battle_Window.GetComponent<Battle_Window>().BossEmergence.gameObject.SetActive(true);
    }

    public void RandomPos_Monster(Transform monster)
    {
        Vector3 pos = Vector3.zero;
        pos.x = Random.Range(Beatle_Zone[2].position.x, Beatle_Zone[3].position.x);
        pos.z = Random.Range(Beatle_Zone[0].position.z, Beatle_Zone[1].position.z);
        pos.y = SpawnPoint_Beatle.position.y;
        monster.position = pos;
    }

    public void Spawn_BeatleKing()
    {
        GameObject Beatle_Obj = Instantiate(BeatleKing, SpawnPoint_BeatleKing);
        Beatle_Obj.transform.localPosition = Vector3.zero;
    }
}
