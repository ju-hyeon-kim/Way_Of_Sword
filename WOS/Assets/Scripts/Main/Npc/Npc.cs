using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    public Npc_IndividualData I_Data;
    public Npc_CommonData C_Data;

    bool isTalking = false; //���� ��ȭ���� üũ�ϴ� bool ��

    #region ���콺 �����ǰ� ��ȣ�ۿ��ϴ� �Լ�
    private void OnMouseEnter() //���콺�� ���� ����� ��
    {
        if(!isTalking) // ��ȭ���� �ƴ϶��
        {
            //�ƿ����� �ѱ�
            Outline_Active();
            //�̸� �� �ѱ�
            NpcName_Label.Inst.gameObject.SetActive(true);
            NpcName_Label.Inst.GetComponentInChildren<TMP_Text>().text = I_Data.Name;
        }
    }
    private void OnMouseOver() //���콺�� Npc�� ����Ű�� �ִ� ����
    {
        NpcName_Label.Inst.transform.position = Camera.main.WorldToScreenPoint(I_Data.NameLabel_Zone.position);
    }
    private void OnMouseExit() //���콺�� ���� ���� ��
    {
        Outline_Unactive(); //�ƿ����� ����

        //�̸� �� ����
        NpcName_Label.Inst.gameObject.SetActive(false);
    }
    #endregion

    //������ �ٶ󺻴�(ȸ��)
    IEnumerator Rotating(Vector3 pos,bool B) // B = true = ��ȭ���� // B = false = ��ȭ ��
    {
        if (B)
        {
            //2.ī�޶� �ִϸ��̼�
            C_Data.MainCam.NpcView(transform);
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

        if (B)
        {
            //3. ��ȭ
            bool b = true;
            while (b)
            {
                if (C_Data.MainCam.Talk_Ready)
                {
                    Connect_Window_Common();

                    b = false;
                }
                yield return null;
            }
            NpcTalk_Window.Inst.gameObject.SetActive(true);
            NpcTalk_Window.Inst.Talking(this); //�λ�
        }
    }

    public void Child_Start_Setting() // �ڽ� ��ũ��Ʈ�� Start()���� �������� ����ϴ� ����
    {
        C_Data.MainCam = Camera.main.transform.parent.GetComponent<MainCam_Controller>();
        C_Data.OrgForward = I_Data.myForward.position;
    }

    public void Reaction(Vector3 p_pos) // �÷��̾ ���� �ɸ� ���׼�
    {
        //1.�÷��̾� ������ ȸ��
        StartCoroutine(Rotating(p_pos, true));
    }

    public void Connect_Window_Common() // NpcTalk_Widow�� Npc_Data�� ���� (�������� ��ҵ���)
    {
        //�̸� ����
        NpcTalk_Window.Inst.Name.text = I_Data.Name;

        //������ ���� = �̸��� ���� �ش� �����ʸ� Ȱ��ȭ �������� ��Ȱ��ȭ
        for (int i = 0; i < NpcTalk_Window.Inst.Npc_Profiles.Length; i++)
        {
            if (NpcTalk_Window.Inst.Npc_Profiles[i].name == gameObject.name)
            {
                NpcTalk_Window.Inst.Npc_Profiles[i].SetActive(true);
            }
            else
            {
                NpcTalk_Window.Inst.Npc_Profiles[i].SetActive(false);
            }
        }
        //�λ� ����
        NpcTalk_Window.Inst.SaveText = I_Data.Greetings;
        //NpcIcon ����
        NpcTalk_Window.Inst.Npc_Icon = I_Data.Npc_Icon;
    }

    

    public void Talk_Start() //��ȭ ����
    {
        //���콺�� ��ȣ�ۿ� ����
        isTalking = true;
        //�ƿ����� ����
        Outline_Unactive();
        //�̸� �� ����
        NpcTalk_Window.Inst.gameObject.SetActive(false);
    }

    //�÷��̾�� ��ȭ ���� �� ���� �ٶ󺸰� �ִ� �������� ���ư���
    public void Talk_End() //��ȭ ��
    {
        //���콺�� ��ȣ�ۿ� �۵�
        isTalking = false;
        //���� �ٶ󺸴� �������� ȸ��
        StartCoroutine(Rotating(C_Data.OrgForward, false));
    }

    public virtual void Outline_Active() { } // �ƿ����� ����
    public virtual void Outline_Unactive() { } // �ƿ����� ����
    public virtual void Event_Of_Child() { } // �ڽĸ��� �ٸ� �̺�Ʈ

    public void Buttons_Setting(Proceeding_Quest PQ) //��ư�� ����
    {
        Button0_Set(PQ);
        Button1_Set(PQ);
        Button2_Set();
    }

    public virtual void Button0_Set(Proceeding_Quest PQ) { } // 0�� ��ư
    public virtual void Button1_Set(Proceeding_Quest PQ) { } // 1�� ��ư
    public void Button2_Set() // ���ư��� ��ư
    {
        NpcTalk_Window.Inst.Buttons[2].GetComponent<Button>().onClick.AddListener(Button2_OnClick);
        NpcTalk_Window.Inst.Buttons[2].SetActive(true);
    }

    public void Button2_OnClick() // ���ư���
    {
        //��ư ��Ȱ��ȭ
        for (int i = 0; i < NpcTalk_Window.Inst.Buttons.Length; i++)
        {
            NpcTalk_Window.Inst.Buttons[i].SetActive(false);
        }
        NpcTalk_Window.Inst.gameObject.SetActive(false);
        // ī�޶� ���� �������
        NpcTalk_Window.Inst.MainCam.ReturnView();
    }
}
