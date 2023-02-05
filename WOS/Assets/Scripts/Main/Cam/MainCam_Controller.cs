using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCam_Controller : MonoBehaviour
{
    public Transform Cam_Target;
    public Transform ChangeViewPos;
    public bool Talk_Ready = false;
    public bool isEvent = false;
    public NpcTalk_Window NpcTalk_Window;

    Vector3 myDir = Vector3.zero;
    float myDist = 0.0f;

    //Npc 대화 이벤트
    Vector3 SavePos;
    Vector3 SaveVec;
    GameObject SaveNpc;
    Vector3 RotDir;

    public void Start_Setting()
    {
        myDir = transform.position - Cam_Target.position;
        transform.rotation = Quaternion.LookRotation(-myDir); // 타겟을 바라보게 회전

        myDist = myDir.magnitude;
        myDir.Normalize();

        StartCoroutine(Follow_CamTarget());
    }

    IEnumerator Follow_CamTarget()
    {
        while(!isEvent)
        {
            //줌
            myDist -= Input.GetAxis("Mouse ScrollWheel");
            myDist = Mathf.Clamp(myDist, 2.0f, 15.0f); // 줌 최소,최대 제한

            transform.position = Cam_Target.position + myDir * myDist;
            yield return null;
        }
    }

    //Npc와 대화시작 -> 시점변경
    //보스몹 클로즈업
    public void ChangeView(Transform target)
    {
        isEvent = true;
        // 시점 변경 전 카메라의 위치와 방향벡터 저장
        SaveNpc = target.gameObject;
        SavePos = transform.position;
        SaveVec = transform.forward;
        // 카메라 시점 변경
        StartCoroutine(Moving(ChangeViewPos.position,true));
        StartCoroutine(Rotating(target.position));
    }

    //Npc와 대화끝 -> 원래 시점으로
    public void ReturnView()
    {
        isEvent = false;
        StartCoroutine(Moving(SavePos,false));
        StartCoroutine(Rotating(SaveVec));
    }

    IEnumerator Moving(Vector3 pos,bool b)
    {
        if (b)
        {
            if(SaveNpc.TryGetComponent<Npc>(out Npc componet))
            {
                componet.Talk_Start();
            }
        }
        else
        {
            SaveNpc.GetComponent<Npc>().Talk_End();
        }

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

        if(b)
        {
            Talk_Ready = true;
        }
        else
        {
            StartCoroutine(Follow_CamTarget());
            Cam_Target.GetComponentInParent<Player_Main>().isEvent = false; // 플레이어 조작 가능
            Talk_Ready = false;
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
            pos.y = ChangeViewPos.position.y;
            RotDir = (pos - ChangeViewPos.position).normalized; // 토크뷰에서 Npc를 바라보는 방향의 벡터 정규화
        }

        while (transform.rotation != Quaternion.LookRotation(RotDir))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(RotDir), Time.deltaTime * 2.0f); // 회전 속도 조절
            yield return null;
        }
    }
}