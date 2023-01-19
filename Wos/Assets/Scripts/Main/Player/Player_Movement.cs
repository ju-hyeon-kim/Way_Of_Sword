using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public bool isEvent = false; // 이벤트 발생시 플레이어 조작 불가
    bool NpcTalking = false; // Npc와 대화 중인지 검사
    GameObject myNpc;

    Coroutine moveCo = null;
    Coroutine rotCo = null;
    float MoveSpeed = 3.0f;
    float RotSpeed = 360.0f;

    void Update()
    {
        if (!isEvent)
        {
            //무빙
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("Ground")))
                {
                    if (moveCo != null)
                    {
                        StopCoroutine(moveCo);
                        moveCo = null;
                    }
                    moveCo = StartCoroutine(Moving(hit.point));
                    if (rotCo != null)
                    {
                        StopCoroutine(rotCo);
                        rotCo = null;
                    }
                    rotCo = StartCoroutine(Rotating(hit.point, false));
                }
            }

            //클릭-Npc대화
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("Npc")))
                {
                    myNpc = hit.collider.gameObject;

                    if (moveCo != null)
                    {
                        StopCoroutine(moveCo);
                        moveCo = null;
                    }
                    moveCo = StartCoroutine(Click_Npc(hit.point));
                    if (rotCo != null)
                    {
                        StopCoroutine(rotCo);
                        rotCo = null;
                    }
                    rotCo = StartCoroutine(Rotating(hit.point, true));
                }
            }
        }
    }

    // 무빙 코루틴
    IEnumerator Moving(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        GetComponent<Animator>().SetBool("Run", true);

        while (dist > 0.0f)
        {
            float delta = MoveSpeed * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        GetComponent<Animator>().SetBool("Run", false);
    }

    // 회전 코루틴
    IEnumerator Rotating(Vector3 pos, bool clicNpc)
    {
        pos.y = transform.position.y;
        Vector3 dir = (pos - transform.position).normalized;
        float Angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f) // 왼쪽으로 돌지 오른쪽으로 돌지 구분
        {
            rotDir = -rotDir;
        }

        while (Angle > 0.0f)
        {
            float delta = RotSpeed * Time.deltaTime;
            if (delta > Angle)
            {
                delta = Angle;
            }
            Angle -= delta;
            transform.Rotate(Vector3.up * rotDir * delta, Space.World);

            yield return null;
        }

        // Npc를 클릭했다면 Npc의 리액션 발생
        if (clicNpc && NpcTalking)
        {
            isEvent = true; // 플레이어의 조작 제한
            myNpc.GetComponent<Npc>().Reaction(gameObject);
        }
    }

    // Npc클릭시 Npc 쪽으로 이동
    IEnumerator Click_Npc(Vector3 pos)
    {
        pos.y = transform.position.y; //클릭지점의 높이가 아닌 바닥높이를 적용하여 벡터생성
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        GetComponent<Animator>().SetBool("Run", true);

        while (dist > 2.0f)
        {
            float delta = MoveSpeed * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        GetComponent<Animator>().SetBool("Run", false);
        NpcTalking = true;
    }

    public void Stop_Movement()
    {
        StopAllCoroutines();
        GetComponent<Animator>().SetBool("Run", false);
    }
}
