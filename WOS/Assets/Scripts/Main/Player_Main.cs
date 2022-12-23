using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Player_Mode
{
    None, Battle, Unbattle
}

public class Player_Main : MonoBehaviour
{
    [SerializeField]
    Player_Mode NowMode = Player_Mode.None;

    public GameObject Skill_Range;
    public Transform Weapon_Back;
    public Transform Weapon_Hand;
    public LayerMask Mask_Ground;
    public LayerMask Mask_Npc;


    Coroutine moveCo = null;
    Coroutine rotCo = null;
    float MoveSpeed = 3.0f;
    float RotSpeed = 360.0f;

    void ChangeMode(Player_Mode pm)
    {
        NowMode = pm;

        switch (pm)
        { 
            case Player_Mode.Unbattle: // ���Ʋ ����� ���
                //������ ��ġ�� �� -> �� �ڷ� �̵� (����ó��?: ���� �̹� ���Ⱑ �� �ڿ� �ִٸ�?) 
                Weapon_Hand.transform.GetChild(0).SetParent(Weapon_Back);
                Weapon_Back.transform.GetChild(0).localPosition = Vector3.zero;
                Weapon_Back.transform.GetChild(0).localRotation = Quaternion.identity;
                //Skill_Range ��Ȱ��ȭ
                Skill_Range.SetActive(false);
                break;
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            ChangeMode(Player_Mode.Unbattle);
        }
    }

    private void Update()
    {
        //����
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

        //Ŭ��-Npc��ȭ
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

    IEnumerator Rotating(Vector3 pos)
    {
        pos.y = transform.position.y;
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
}
