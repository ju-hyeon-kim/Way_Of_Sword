using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character_Movement : Character_Property // 이동,회전,드랍
{
    [Header("-----Character_Movement-----")]
    protected float RotSpeed = 360.0f;
    protected Coroutine moveCo = null;
    Coroutine rotCo = null;

    //for Npc
    protected bool isMovEnd = false;
    protected bool isRotEnd = false;
    protected bool isNpc = false;
    UnityAction movrotend_action = null;

    protected void MoveToPos(Vector3 pos, UnityAction Action_AfterMoving = null, bool isMov = true, bool isRot = true)
    // bool isMov(isRot)는 이동(회전)을 할지 말지 결정
    {
        movrotend_action = Action_AfterMoving;

        if (isMov)
        {
            pos.y = transform.position.y;

            if (moveCo != null)
            {
                StopCoroutine(moveCo);
                moveCo = null;
            }
            moveCo = StartCoroutine(Moving(pos));
        }

        if (isRot)
        {
            if (rotCo != null)
            {
                StopCoroutine(rotCo);
                rotCo = null;
            }
            rotCo = StartCoroutine(Rotating(pos));
        }
    }

    // 무빙 코루틴
    IEnumerator Moving(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        myAnim.SetBool("Move", true);

        float range = 0.0f;
        if (movrotend_action != null || isNpc)
        {
            range = myStat.arange();
        }

        while (dist > range)
        {
            float delta = myStat.mspeed() * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        myAnim.SetBool("Move", false);

        isMovEnd = true;
        MovRotEnd_Action();
        //for Npc
        /*if(isNpc)
        {
            isMovEnd = true;
            MovRotEnd_NpcEvent();
        }*/
    }

    // 회전 코루틴
    IEnumerator Rotating(Vector3 pos)
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
            transform.Rotate(Vector3.up * rotDir * delta);
            yield return null;
        }

        isRotEnd = true;
        MovRotEnd_Action();
        //for Npc
        /*if(isNpc)
        {
            isRotEnd = true;
            MovRotEnd_NpcEvent();
        }*/
    }
    public virtual void MovRotEnd_NpcEvent() { }  // Npc를 클릭했다면 Npc의 리액션 발생

    void MovRotEnd_Action()
    {
        if(isMovEnd && isRotEnd)
        {
            isMovEnd = false;
            isRotEnd = false;
            movrotend_action?.Invoke();
        }
    }
}