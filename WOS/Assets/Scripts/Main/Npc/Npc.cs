using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Npc : MonoBehaviour
{
    public Npc_Data Datas;

    public MainCam_Controller MainCam;
    public Material OutLine;
    public Renderer[] RendererList;
    public GameObject NpcName_Label;
    public Transform NameLabel_Zone;
    public GameObject NpcTalk_Window;
    public bool isEvent = false;

    List<Material[]> Origin = new List<Material[]>();
    Vector3 OrgForward;
    
    
    private void Start()
    {
        OrgForward = Datas.myForward.position;

        for (int i = 0; i < RendererList.Length; ++i)
        {
            Origin.Add(RendererList[i].materials);
        }
    }

    private void Update()
    {
        if(!isEvent)
        {
            //���콺 �����ǰ� ��ȣ�ۿ�(�ƿ�����)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("Npc")))
            {
                //�ƿ����� ����
                for (int i = 0; i < RendererList.Length; ++i)
                {
                    Material[] Change = new Material[2];
                    Change[0] = RendererList[i].materials[0];
                    Change[1] = OutLine;
                    RendererList[i].materials = Change;
                }

                //�̸� �� �ѱ�
                NpcName_Label.SetActive(true);
                NpcName_Label.GetComponentInChildren<TMP_Text>().text = Datas.Name;
                NpcName_Label.transform.position = Camera.main.WorldToScreenPoint(NameLabel_Zone.position);
            }
            else
            {
                NameOutLine_false(); //�ƿ����� ���� & ���Ӷ� ����
            }
        }
        else // �̺�Ʈ �߻���
        {
            NameOutLine_false(); //�ƿ����� ���� & ���Ӷ� ����
        }
    }

    public void Reaction(Vector3 p_pos) // �÷��̾ ���� �ɸ� ���׼�
    {
        //0.���콺 �����ǰ� ��ȣ�ۿ� �ߴ�
        isEvent = true;
        //1.�÷��̾� ������ ȸ��
        StartCoroutine(Rotating(p_pos,"��ȭ"));
    }

    //������ �ٶ󺻴�(ȸ��)
    IEnumerator Rotating(Vector3 pos,string s)
    {
        if (s == "��ȭ")
        {
            //2.ī�޶� �ִϸ��̼�
            MainCam.NpcView(transform);
        }

        //ȸ��
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
            float delta = 360.0f * Time.deltaTime;
            if (delta > Angle)
            {
                delta = Angle;
            }
            Angle -= delta;
            transform.Rotate(Vector3.up * rotDir * delta, Space.World);

            yield return null;
        }

        if (s == "��ȭ")
        {
            //3. ��ȭ
            bool b = true;
            while (b)
            {
                if (MainCam.Talk_Ready)
                {
                    Connect_Window();
                    b = false;
                }
                yield return null;
            }
            NpcTalk_Window.SetActive(true);
            NpcTalk_Window.GetComponent<NpcTalk_Window>().OnTyping();
        }
    }

    public void Connect_Window() // Talk_Widow�� Npc_Data�� ����
    {
        NpcTalk_Window temp = NpcTalk_Window.GetComponent<NpcTalk_Window>();
        temp.Profile.sprite = Datas.Profile;
        temp.Name.text = Datas.Name;
        temp.SaveText = Datas.Talk;
    }

    //�÷��̾�� ��ȭ ���� �� ���� �ٶ󺸰� �ִ� �������� ���ư���
    public void ReturnForward()
    {
        StartCoroutine(Rotating(OrgForward, "������ ������ �ٶ�"));
    }

    void NameOutLine_false()
    {
        //�ƿ����� ����
        for (int i = 0; i < RendererList.Length; ++i)
        {
            RendererList[i].materials = Origin[i];
        }
        //�̸� �� ����
        NpcName_Label.SetActive(false);
    }
}
