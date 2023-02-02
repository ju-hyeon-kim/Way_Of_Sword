using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Manager_Forest : MonoBehaviour
{
    public Transform[] Guide_Tartgets;
    public GameObject Beatle;
    public Transform SpawnPoint_Monster;
    public Transform[] Beatle_Zone; // 비틀의 로밍 제한 구역

    int NomalMonster_Count = 5; // 비틀 생성 갯수

    private void Awake()
    {
        Play_Starter.Inst.Start_Call();
    }

    void Start()
    {
        Dont_Destroy_Data.Inst.Manager_Quest.Guide_Tartgets = Guide_Tartgets;
        Dont_Destroy_Data.Inst.Player.GetComponent<Player_Main>().Change_Mode(Player_Mode.Battle);

        for (int i = 0; i < NomalMonster_Count; i++)
        {
            //몬스터 소환
            GameObject Beatle_Obj = Instantiate(Beatle, SpawnPoint_Monster);
            //랜덤한 위치로 이동시켜줌 (Beatle_Zone안에서)
            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(Beatle_Zone[2].position.x, Beatle_Zone[3].position.x);
            pos.z = Random.Range(Beatle_Zone[0].position.z, Beatle_Zone[1].position.z);
            pos.y = SpawnPoint_Monster.position.y;
            Beatle_Obj.transform.position = pos;

            //소환한 몬스터에게 로밍구역 값을 전달
            Beatle_Obj.GetComponent<Monster>().Roaming_Zone = Beatle_Zone;
        }
    }
}
