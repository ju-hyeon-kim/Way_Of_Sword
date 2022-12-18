using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Animations;
using UnityEngine;

public class Player_Tuto : MonoBehaviour
{
    public GameObject Dummy;
    public bool PlayerTurn = false;
    public LayerMask Mask_Ground = default;
    public LayerMask Mask_Character = default;
    float MoveSpeed = 3.0f;
    float RotSpeed = 360.0f;
    public float AttackRange = 2f;

    Coroutine moveCo = null;
    Coroutine rotCo = null;

    void Update()
    {
        //¹«ºù
        if (PlayerTurn)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, Mask_Ground))
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
                    rotCo = StartCoroutine(Rotating(hit.point));
                }
            }
            else if (Input.GetMouseButtonDown(0) && !GetComponent<Animator>().GetBool("isAttacking"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, Mask_Character))
                {
                    if (moveCo != null)
                    {
                        StopCoroutine(moveCo);
                        moveCo = null;
                    }
                    moveCo = StartCoroutine(Attaking(hit.point));
                    if (rotCo != null)
                    {
                        StopCoroutine(rotCo);
                        rotCo = null;
                    }
                    rotCo = StartCoroutine(Rotating(hit.point));
                }
            }
        }
    }

    IEnumerator Rotating(Vector3 pos)
    {
        Vector3 dir = (pos - transform.position).normalized;
        float Angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f)
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
    }

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

    IEnumerator Attaking(Vector3 pos)
    {
        pos.y = transform.position.y;
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        GetComponent<Animator>().SetBool("Run", true);

        while (dist > AttackRange)
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
        GetComponent<Animator>().SetTrigger("Attack1");
        Dummy.GetComponent<Dummy>().OnDamage();
    }
}
