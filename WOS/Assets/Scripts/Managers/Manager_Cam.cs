using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Cam : MonoBehaviour
{
    public Transform Cam_Target;
    public Transform NpcTalk_View;
    public bool Talk_Ready = false;
    public bool isEvent = false;

    Vector3 myDir = Vector3.zero;
    Vector3 SavePos;
    Vector3 SaveVec;
    GameObject SaveNpc;
    Vector3 RotDir;
    

    private void Start()
    {
        myDir = transform.position - Cam_Target.position;
    }

    private void Update()
    {
        if(!isEvent)
        {
            transform.position = Cam_Target.position + myDir;
        }
    }

    //Npc�� ��ȭ�� ��������
    public void NpcView(Transform npc_pos)
    {
        isEvent = true;
        // ���� ���� �� ī�޶��� ��ġ�� ���⺤�� ����
        SaveNpc = npc_pos.gameObject;
        SavePos = transform.position;
        SaveVec = transform.forward;
        // ī�޶� ���� ����
        StartCoroutine(Moving(NpcTalk_View.position,true));
        StartCoroutine(Rotating(npc_pos.position));
    }

    public void ReturnView()
    {
        StartCoroutine(Moving(SavePos,false));
        StartCoroutine(Rotating(SaveVec));
    }

    IEnumerator Moving(Vector3 pos,bool b)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        while (dist > 0.0f)
        {
            float delta = 10.0f * Time.deltaTime; // �� ���ǵ�
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta, Space.World);
            yield return null;
        }

        if(!b)
        {
            isEvent = false; // �̺�Ʈ�� ���� �˸�
            Cam_Target.GetComponentInParent<Player_Main>().isEvent = false; // �÷��̾� ���� ����
            SaveNpc.GetComponent<Npc>().isEvent = false; // Npc�� ���콺 �����ǰ��� ��ȣ�ۿ� Ȱ��ȭ
            SaveNpc.GetComponent<Npc>().ReturnForward(); // Npc�� ������ ������ �ٶ�
            Talk_Ready = false;
        }
        else
        {
            Talk_Ready = true;
        }
    }
    IEnumerator Rotating(Vector3 pos)
    {
        if (pos == SaveVec) // ���� �������� ���ư� ��
        {
            RotDir = pos;
            RotDir.Normalize();// SaveVec�� ����ȭ
        }
        else // Npc�� ��ȭ �� ���� ����
        {
            pos.y = NpcTalk_View.position.y;
            RotDir = (pos - NpcTalk_View.position).normalized; // ��ũ�信�� Npc�� �ٶ󺸴� ������ ���� ����ȭ
        }

        while (transform.rotation != Quaternion.LookRotation(RotDir))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(RotDir), Time.deltaTime * 2.0f); // ȸ�� �ӵ� ����
            yield return null;
        }
    }
}
