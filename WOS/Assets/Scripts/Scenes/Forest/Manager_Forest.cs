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
    public Transform[] Beatle_Zone; // ��Ʋ�� �ι� ���� ����
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
            //��������Ʈ�� ������ ��ġ�� ������ (Beatle_Zone�ȿ���)
            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(Beatle_Zone[2].position.x, Beatle_Zone[3].position.x);
            pos.z = Random.Range(Beatle_Zone[0].position.z, Beatle_Zone[1].position.z);
            pos.y = SpawnPoints_Monster[i].position.y;
            SpawnPoints_Monster[i].position = pos;

            //���� ��ȯ
            GameObject Beatle_Obj = Instantiate(Beatle, SpawnPoints_Monster[i]);
            //��ȯ�� ���Ϳ��� �ιֱ��� ���� ����
            SpawnPoints_Monster[i].GetChild(0).GetComponent<Monster>().Roaming_Zone = Beatle_Zone;
        }
    }
}
