using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Player_Mode
{
    None, Battle, Unbattle
}

public class Player_Main : MonoBehaviour
{
    public Player_Mode NowMode = Player_Mode.None;

    public GameObject Skill_Range;
    public Transform Weapon_Back;
    public Transform Weapon_Hand;
    public bool isEvent = false; // �̺�Ʈ �߻� �÷��̾� ���� �Ұ�

    GameObject myNpc;
    Coroutine moveCo = null;
    Coroutine rotCo = null;
    float MoveSpeed = 3.0f;
    float RotSpeed = 360.0f;
    bool NpcTalking = false; // Npc�� ��ȭ ������ �˻�

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

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            ChangeMode(Player_Mode.Unbattle);
        }
    }

    private void Update()
    {
        if(!isEvent)
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
            myNpc.GetComponent<Npc>().Reaction(this.transform.position);
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
}
