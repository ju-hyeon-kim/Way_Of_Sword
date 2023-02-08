using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character_Movement : Character_Property // �̵�,ȸ��,���
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
        // bool isMov(isRot)�� �̵�(ȸ��)�� ���� ���� ����
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

    // ���� �ڷ�ƾ
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
        /*ChildAction�� ���� �ƴ϶�� ���� ( ChildAction = �ڽĿ� ���� �ٸ��� ����Ǵ� �Լ� )
        -�÷��̾��� ���: ���� Anim ����
        -������ ���: ������ ��ġ�� ���̵� ���·� ���ư� -> ChangeState()*/
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
            //�̵�
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
                    //����
                    playTime = 0.0f;
                    myAnim.SetTrigger("Attack");
                }
            }

            //ȸ��
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

    public virtual void P_MoveEnd_NpcAction() { }  // P - Npc�� Ŭ���ߴٸ� Npc�� ���׼� �߻�
    public virtual void P_RotEnd_NpcAction() { }  // P - Npc�� Ŭ���ߴٸ� Npc�� ���׼� �߻�
}
