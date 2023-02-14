using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : CharacterProperty
{
    Coroutine moveCo = null;
    Coroutine rotCo = null;
    Coroutine attackCo = null;

    protected void AttackTarget(Transform target, float attackRange, float attackSpeed)
    {
        StopAllCoroutines();
        attackCo = StartCoroutine(AttackingTarget(target, attackRange, attackSpeed));
    }
   
    protected void MoveToPosition(Vector3 pos, UnityAction done = null, bool Rot = true)
    {
        if(moveCo != null)
        {
            StopCoroutine(moveCo);
            moveCo = null;
        }
        moveCo = StartCoroutine(MovingToPosition(pos, done));
      
        if(Rot)
        {
            if (rotCo != null)
            {
                StopCoroutine(rotCo);
                rotCo = null;
            }
            rotCo = StartCoroutine(RotatingToPosition(pos));
        }

        if (attackCo != null)
        {
            StopCoroutine(attackCo);
            attackCo = null;
        }
        
    }
    IEnumerator RotatingToPosition(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        dir.Normalize();
        float angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -rotDir;
        }
        while (angle > 0.0f)
        {
            float delta = myStat.RotSpeed * Time.deltaTime;
            if (delta > angle)
            {
                delta = angle;
            }
            angle -= delta;
            transform.Rotate(Vector3.up * rotDir * delta, Space.World);
            yield return null;
        }
    }
    IEnumerator MovingToPosition(Vector3 pos, UnityAction done)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();
        myAnim.SetBool("IsMoving", true);
        while (dist > 0.0f)
        {
            float delta = myStat.MoveSpeed * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }
        myAnim.SetBool("IsMoving", false);
        done?.Invoke();
    }

    IEnumerator AttackingTarget(Transform target, float attackRange, float attackSpeed)
    {
        float playTitme = 0.0f;
        float delta = 0.0f;
        while(target != null)
        {
            if (!myAnim.GetBool("IsAttacking")) playTitme += Time.deltaTime;
            //이동
            Vector3 dir = target.position - transform.position;
            dir.y = 0;
            float dist = dir.magnitude;
            dir.Normalize();
            if(dist > attackRange)
            {
                myAnim.SetBool("IsMoving", true);
                delta = myStat.MoveSpeed * Time.deltaTime;
                if(delta > dist)
                {
                    delta = dist;
                }
                transform.Translate(dir * delta, Space.World);
            }
            else
            {
                myAnim.SetBool("IsMoving", false);
                if(playTitme >= attackSpeed)
                {
                    //공격
                    playTitme = 0.0f;
                    myAnim.SetTrigger("Attack");
                }
            }

            delta = myStat.RotSpeed * Time.deltaTime;
            float angle = Vector3.Angle(dir, transform.forward);
            float rotDir = 1.0f;
            if(Vector3.Dot(transform.right,dir) < 0.0f)
            {
                rotDir = -rotDir;
            }
            if(delta > angle)
            {
                delta = angle;
            }
            transform.Rotate(Vector3.up * delta * rotDir, Space.World);
            yield return null;
        }
    }
}
