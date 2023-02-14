using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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

    protected void MoveToPos(Vector3 pos, UnityAction Action_AfterMoving = null, bool isMov = true, bool isRot = true)
    // bool isMov(isRot)�� �̵�(ȸ��)�� ���� ���� ����
    {
        if (isMov)
        {
            pos.y = transform.position.y;

            if (moveCo != null)
            {
                StopCoroutine(moveCo);
                moveCo = null;
            }
            moveCo = StartCoroutine(Moving(pos, Action_AfterMoving));
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
    IEnumerator Moving(Vector3 pos, UnityAction Action_AfterMoving)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        myAnim.SetBool("Move", true);

        float range = 0.0f;
        if (Action_AfterMoving != null || isNpc)
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

        Action_AfterMoving?.Invoke();
        /*Action_AM�� ���� �ƴ϶�� ���� ( ChildAction = �ڽĿ� ���� �ٸ��� ����Ǵ� �Լ� )
        -�÷��̾��� ���: ���� Anim ����
        -������ ���: ������ ��ġ�� ���̵� ���·� ���ư� -> ChangeState()*/

        //for Npc
        if(isNpc)
        {
            isMovEnd = true;
            MovRotEnd_NpcEvent();
        }
       
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

        //for Npc
        if(isNpc)
        {
            isRotEnd = true;
            MovRotEnd_NpcEvent();
        }
    }
    public virtual void MovRotEnd_NpcEvent() { }  // Npc�� Ŭ���ߴٸ� Npc�� ���׼� �߻�
}