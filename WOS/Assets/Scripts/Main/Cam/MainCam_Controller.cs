using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainCam_Controller : MonoBehaviour
{
    public Transform Cam_Target;
    public Transform ChangeViewPos;
    public bool Talk_Ready = false;
    public bool isEvent = false;
    public NpcTalk_Window NpcTalk_Window;
    public GameObject[] Unactive_Uis;
    public Animator Boss_Introduce;
    public Animator Battle_Start;
    public UnityAction<BossMonster.STATE> Function;

    Vector3 myDir = Vector3.zero;
    float myDist = 0.0f;

    //Npc ��ȭ �̺�Ʈ
    Vector3 SavePos;
    Vector3 SaveVec;
    GameObject SaveNpc;
    Vector3 RotDir;

    bool MovFinish = false;
    bool RotFinish = false;

    public void Start_Setting()
    {
        myDir = transform.position - Cam_Target.position;
        transform.rotation = Quaternion.LookRotation(-myDir); // Ÿ���� �ٶ󺸰� ȸ��

        myDist = myDir.magnitude;
        myDir.Normalize();

        StartCoroutine(Follow_CamTarget());
    }

    IEnumerator Follow_CamTarget()
    {
        while(!isEvent)
        {
            //��
            myDist -= Input.GetAxis("Mouse ScrollWheel");
            myDist = Mathf.Clamp(myDist, 2.0f, 15.0f); // �� �ּ�,�ִ� ����

            transform.position = Cam_Target.position + myDir * myDist;
            yield return null;
        }
    }

    //Npc�� ��ȭ���� -> ��������
    //������ Ŭ�����
    public void ChangeView(Transform target)
    {
        isEvent = true;
        // ���� ���� �� ī�޶��� ��ġ�� ���⺤�� ����
        SaveNpc = target.gameObject;
        if (SaveNpc.TryGetComponent<BossMonster>(out BossMonster componet))
        {
            Uis_OnOff(false);
        }
        SavePos = transform.position;
        SaveVec = transform.forward;
        // ī�޶� ���� ����
        StartCoroutine(Moving(ChangeViewPos.position,true));
        StartCoroutine(Rotating(target.position));
    }

    //Npc�� ��ȭ�� -> ���� ��������
    public void ReturnView()
    {
        isEvent = false;
        StartCoroutine(Moving(SavePos,false)); //null����
        StartCoroutine(Rotating(SaveVec));

        Function(BossMonster.STATE.Battle);

        Uis_OnOff(true);
    }

    IEnumerator Moving(Vector3 pos,bool b)
    {
        if (SaveNpc.TryGetComponent<Npc>(out Npc componet))
        {
            if (b)
            {
                componet.Talk_Start();
            }
            else
            {
                componet.Talk_End();
            }
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

            MovFinish = true;
            ViewChangeFinish();
        }
        else
        {
            StartCoroutine(Follow_CamTarget());
            Cam_Target.GetComponentInParent<Player>().ControlPossible = true; // �÷��̾� ���� ����
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
            pos.y = ChangeViewPos.position.y;
            RotDir = (pos - ChangeViewPos.position).normalized; // ��ũ�信�� Npc�� �ٶ󺸴� ������ ���� ����ȭ
        }

        while (transform.rotation != Quaternion.LookRotation(RotDir))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(RotDir), Time.deltaTime * 2.0f); // ȸ�� �ӵ� ����
            yield return null;
        }

        RotFinish = true;
        ViewChangeFinish();
    }

    void ViewChangeFinish()
    {
        if(MovFinish && RotFinish)
        {
            if (SaveNpc.TryGetComponent<BossMonster>(out BossMonster componet))
            {
                Boss_Introduce.SetBool("Show", true);
                componet.ChangeState(Monster_Movement.STATE.Appear);
                StartCoroutine(TimeChecking(2.0f));
                MovFinish = false;
                RotFinish = false;
            }
        }
    }

    IEnumerator TimeChecking(float time)
    {
        yield return new WaitForSeconds(time);
        Boss_Introduce.SetBool("Show", false);
        Battle_Start.gameObject.SetActive(true);
        Battle_Start.SetTrigger("Show");
    }

    void Uis_OnOff(bool b)
    {
        for (int i = 0; i < 2; i++)
        {
            Unactive_Uis[i].SetActive(b);
        }
    }
}