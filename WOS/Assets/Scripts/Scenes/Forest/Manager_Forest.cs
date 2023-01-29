using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Manager_Forest : MonoBehaviour
{
    public Transform[] Guide_Tartgets;
    public GameObject Beatle;
    public Transform[] SpawnPoints_Monster;
    public Transform[] Beatle_Zone; // 비틀의 로밍 제한 구역
    public AnimatorController  Player_Battle;

    private void Awake()
    {
        Play_Starter.Inst.Start_Call();
    }

    void Start()
    {
        Manager_Quest.Inst.Guide_Tartgets = Guide_Tartgets;

        Dont_Destroy_Data.Inst.Map_Window.gameObject.SetActive(false);
        Dont_Destroy_Data.Inst.Player.GetComponent<Player_Main>().Change_Mode(Player_Mode.Battle);
        Dont_Destroy_Data.Inst.Player.GetComponent<Animator>().runtimeAnimatorController = Player_Battle;
        Time.timeScale = 1.0f;

        for (int i = 0; i < SpawnPoints_Monster.Length; i++)
        {
            //스폰포인트가 랜덤한 위치로 결정됨 (Beatle_Zone안에서)
            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(Beatle_Zone[2].position.x, Beatle_Zone[3].position.x);
            pos.z = Random.Range(Beatle_Zone[0].position.z, Beatle_Zone[1].position.z);
            pos.y = SpawnPoints_Monster[i].position.y;
            SpawnPoints_Monster[i].position = pos;

            //몬스터 소환
            GameObject Beatle_Obj = Instantiate(Beatle, SpawnPoints_Monster[i]);
            //소환한 몬스터에게 로밍구역 값을 전달
            SpawnPoints_Monster[i].GetChild(0).GetComponent<Monster>().Roaming_Zone = Beatle_Zone;
        }
    }
}
