using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character_Movement : Character_Property // �̵�,ȸ��,���
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
    // bool isMov(isRot)�� �̵�(ȸ��)�� ���� ���� ����
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

    // ���� �ڷ�ƾ
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

    // ȸ�� �ڷ�ƾ
    IEnumerator Rotating(Vector3 pos)
    {
        pos.y = transform.position.y;
        Vector3 dir = (pos - transform.position).normalized;
        float Angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f) // �������� ���� ���������� ���� ����
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
    public virtual void MovRotEnd_NpcEvent() { }  // Npc�� Ŭ���ߴٸ� Npc�� ���׼� �߻�

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