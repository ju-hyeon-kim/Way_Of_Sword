using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public bool isEvent = false; // �̺�Ʈ �߻��� �÷��̾� ���� �Ұ�
    bool NpcTalking = false; // Npc�� ��ȭ ������ �˻�
    GameObject myNpc;

    Coroutine moveCo = null;
    Coroutine rotCo = null;
    float MoveSpeed = 3.0f;
    float RotSpeed = 360.0f;

    void Update()
    {
        if (!isEvent)
        {
            //����
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

            //Ŭ��-Npc��ȭ
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

    // ���� �ڷ�ƾ
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

    // ȸ�� �ڷ�ƾ
    IEnumerator Rotating(Vector3 pos, bool clicNpc)
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
            transform.Rotate(Vector3.up * rotDir * delta, Space.World);

            yield return null;
        }

        // Npc�� Ŭ���ߴٸ� Npc�� ���׼� �߻�
        if (clicNpc && NpcTalking)
        {
            isEvent = true; // �÷��̾��� ���� ����
            myNpc.GetComponent<Npc>().Reaction(gameObject);
        }
    }

    // NpcŬ���� Npc ������ �̵�
    IEnumerator Click_Npc(Vector3 pos)
    {
        pos.y = transform.position.y; //Ŭ�������� ���̰� �ƴ� �ٴڳ��̸� �����Ͽ� ���ͻ���
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
