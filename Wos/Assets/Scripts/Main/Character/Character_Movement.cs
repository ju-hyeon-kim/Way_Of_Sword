using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character_Movement : Character_Property // 이동,회전,드랍
{
    [Header("-----Character_Movement-----")]
    public float AttackRange = 1.0f;
    public float MoveSpeed = 3.0f;

    float RotSpeed = 360.0f;
    protected Coroutine moveCo = null;
    Coroutine rotCo = null;

    protected void AttackTarget(Transform target, float AttackRange, float AttackDelay)
    {
        StopAllCoroutines();
        StartCoroutine(AttackingTarget(target, AttackRange, AttackDelay));
    }
    protected bool Move_To_Target = false; 

    protected void MoveToPos(Vector3 pos, UnityAction ChildAction = null,bool isMov = true, bool isRot = true) 
        // bool isMov(isRot)는 이동(회전)을 할지 말지 결정
    {
        if(isMov)
        {
            pos.y = transform.position.y;

            if (moveCo != null)
            {
                StopCoroutine(moveCo);
                moveCo = null;
            }
            moveCo = StartCoroutine(Moving(pos, ChildAction));
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
    IEnumerator Moving(Vector3 pos, UnityAction ChildAction)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        myAnim.SetBool("Move", true);

        float range = 0.0f;
        if(Move_To_Target)
        {
            range = AttackRange;
        }

        while (dist > range)
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

        myAnim.SetBool("Move", false);

        if (Move_To_Target)
        {
            P_MoveEnd_NpcAction();
        }

        ChildAction?.Invoke();
        /*ChildAction이 널이 아니라면 실행 ( ChildAction = 자식에 따라 다르게 실행되는 함수 )
        -플레이어의 경우: 공격 Anim 실행
        -몬스터의 경우: 무빙을 마치고 아이들 상태로 돌아감 -> ChangeState()*/
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

        if (Move_To_Target)
        {
            P_RotEnd_NpcAction();
        }
    }

    IEnumerator AttackingTarget(Transform target, float AttackRange, float AttackDelay)
    {
        float playTime = 0.0f;
        float delta = 0.0f;
        while (target != null)
        {
            if(!myAnim.GetBool("isAttacking")) playTime += Time.deltaTime;
            //이동
            Vector3 dir = target.position - transform.position;
            float dist = dir.magnitude;
            dir.Normalize();
            if (dist > AttackRange)
            {
                myAnim.SetBool("Move", true);
                delta = MoveSpeed * Time.deltaTime;
                if (delta > dist)
                {
                    delta = dist;
                }
                transform.Translate(dir * delta, Space.World);
            }
            else
            {
                myAnim.SetBool("Move", false);
                if(playTime >= AttackDelay)
                {
                    //공격
                    playTime = 0.0f;
                    myAnim.SetTrigger("Attack");
                }
            }

            //회전
            delta = RotSpeed * Time.deltaTime;
            float Angle = Vector3.Angle(dir, transform.forward);
            float rotDir = 1.0f;
            if(Vector3.Dot(transform.right, dir) < 0.0f)
            {
                rotDir = -rotDir;
            }
            if(delta > Angle)
            {
                delta = Angle;
            }
            transform.Rotate(Vector3.up * delta * rotDir, Space.World);
            
            yield return null;
        }
        myAnim.SetBool("Move", false);
    }

    public virtual void P_MoveEnd_NpcAction() { }  // P - Npc를 클릭했다면 Npc의 리액션 발생
    public virtual void P_RotEnd_NpcAction() { }  // P - Npc를 클릭했다면 Npc의 리액션 발생
}
