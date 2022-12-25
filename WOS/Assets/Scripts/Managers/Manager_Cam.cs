using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Cam : MonoBehaviour
{
    public Transform Cam_Target;
    public Transform NpcTalk_View;
    public bool Talk_Ready = false;
    public bool isEvent = false;

    Vector3 myDir = Vector3.zero;
    Vector3 SavePos;
    Vector3 SaveVec;
    GameObject SaveNpc;
    Vector3 RotDir;
    

    private void Start()
    {
        myDir = transform.position - Cam_Target.position;
    }

    private void Update()
    {
        if(!isEvent)
        {
            transform.position = Cam_Target.position + myDir;
        }
    }

    //Npc와 대화시 시점변경
    public void NpcView(Transform npc_pos)
    {
        isEvent = true;
        // 시점 변경 전 카메라의 위치와 방향벡터 저장
        SaveNpc = npc_pos.gameObject;
        SavePos = transform.position;
        SaveVec = transform.forward;
        // 카메라 시점 변경
        StartCoroutine(Moving(NpcTalk_View.position,true));
        StartCoroutine(Rotating(npc_pos.position));
    }

    public void ReturnView()
    {
        StartCoroutine(Moving(SavePos,false));
        StartCoroutine(Rotating(SaveVec));
    }

    IEnumerator Moving(Vector3 pos,bool b)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        while (dist > 0.0f)
        {
            float delta = 10.0f * Time.deltaTime; // 줌 스피드
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        if(!b)
        {
            isEvent = false; // 이벤트의 끝을 알림
            Cam_Target.GetComponentInParent<Player_Main>().isEvent = false; // 플레이어 조작 가능
            SaveNpc.GetComponent<Npc>().isEvent = false; // Npc의 마우스 포지션과의 상호작용 활성화
            SaveNpc.GetComponent<Npc>().ReturnForward(); // Npc가 원래의 방향을 바라봄
            Talk_Ready = false;
        }
        else
        {
            Talk_Ready = true;
        }
    }
    IEnumerator Rotating(Vector3 pos)
    {
        if (pos == SaveVec) // 원래 시점으로 돌아갈 때
        {
            RotDir = pos;
            RotDir.Normalize();// SaveVec을 정규화
        }
        else // Npc와 대화 시 시점 변경
        {
            pos.y = NpcTalk_View.position.y;
            RotDir = (pos - NpcTalk_View.position).normalized; // 토크뷰에서 Npc를 바라보는 방향의 벡터 정규화
        }

        while (transform.rotation != Quaternion.LookRotation(RotDir))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(RotDir), Time.deltaTime * 2.0f); // 회전 속도 조절
            yield return null;
        }
    }
}
