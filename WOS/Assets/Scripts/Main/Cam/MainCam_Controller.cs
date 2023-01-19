using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCam_Controller : MonoBehaviour
{
    public Transform Cam_Target;
    public Transform NpcTalk_View;
    public bool Talk_Ready = false;
    public bool isEvent = false;
    public NpcTalk_Window NpcTalk_Window;

    Vector3 myDir = Vector3.zero;
    float myDist = 0.0f;

    //Npc ��ȭ �̺�Ʈ
    Vector3 SavePos;
    Vector3 SaveVec;
    GameObject SaveNpc;
    Vector3 RotDir;

    private void Start()
    {
        
    }

    public void StartSetting()
    {
        myDir = Cam_Target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(myDir); // Ÿ���� �ٶ󺸰� ȸ��

        myDist = myDir.magnitude;
        myDir.Normalize();
    }

    private void Update()
    {
        if(!isEvent)
        {
            //��
            myDist -= Input.GetAxis("Mouse ScrollWheel");
            myDist = Mathf.Clamp(myDist, 2.0f, 15.0f); // �� �ּ�/�ִ� ����
            
            transform.position = Cam_Target.position - myDir * myDist;
        }
    }

    //Npc�� ��ȭ���� -> ��������
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

    //Npc�� ��ȭ�� -> ���� ��������
    public void ReturnView()
    {
        isEvent = false;
        StartCoroutine(Moving(SavePos,false));
        StartCoroutine(Rotating(SaveVec));
    }

    IEnumerator Moving(Vector3 pos,bool b)
    {
        if (b)
        {
            SaveNpc.GetComponent<Npc>().Talk_Start();
        }
        else
        {
            SaveNpc.GetComponent<Npc>().Talk_End();
        }

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

        if(b)
        {
            Talk_Ready = true;
        }
        else
        {
            Cam_Target.GetComponentInParent<Player_Main>().isEvent = false; // �÷��̾� ���� ����
            Talk_Ready = false;
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