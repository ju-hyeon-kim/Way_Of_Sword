using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Story1 : MonoBehaviour
{
    public GameObject Weapon_Back;
    public bool PlayerTurn = false;
    public bool PlayerTurn_rotdoor = false;

    public LayerMask pickMask = default;
    public float MoveSpeed = 1.0f ;
    public float RotSpeed = 360.0f;
    public Transform Door_Zone;

    Coroutine moveCo = null;
    Coroutine rotCo = null;

    // Start is called before the first frame update
    void Start()
    {
        Weapon_Back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerTurn)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, pickMask))
                {
                    if(moveCo != null)
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
                    rotCo =StartCoroutine(Rotating(hit.point));
                }
            }
        }
        if(PlayerTurn_rotdoor)
        {
            StartCoroutine(Rotating(Door_Zone.position));
            PlayerTurn_rotdoor = false;
        }
    }

    IEnumerator Rotating(Vector3 pos)
    {
        Vector3 dir = (pos - transform.position).normalized;
        float Angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if(Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -rotDir;
        }

        while(Angle > 0.0f)
        {
            float delta = RotSpeed * Time.deltaTime;
            if(delta > Angle)
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

        GetComponent<Animator>().SetBool("Walk", true);

        while(dist> 0.0f)
        {
            float delta = MoveSpeed * Time.deltaTime;
            if(delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        GetComponent<Animator>().SetBool("Walk", false);
    }

    IEnumerator Rotate_Door(Vector3 pos)
    {
        PlayerTurn_rotdoor = false; // 한번만 실행 되게

        Vector3 dir = (pos - transform.position).normalized;
        float Angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -rotDir;
        }

        while (Angle > 0.0f)
        {
            
            float delta = (RotSpeed * Time.deltaTime) * 0.5f; // 0.5f는 속도 조절
            if (delta > Angle)
            {
                delta = Angle;
            }
            Angle -= delta;

            transform.Rotate(Vector3.up * rotDir * delta, Space.World);
            yield return null;
        }
    }

    public void StopMove()
    {
        StopAllCoroutines();
        GetComponent<Animator>().SetBool("Walk", false);
    }
}
