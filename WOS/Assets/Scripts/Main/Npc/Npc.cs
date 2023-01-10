using System.Collections;
using TMPro;
using UnityEngine;

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
            C_Data.NpcName_Label_obj.SetActive(true);
            C_Data.NpcName_Label_obj.GetComponentInChildren<TMP_Text>().text = I_Data.Name;
        }
    }
    private void OnMouseOver() //���콺�� Npc�� ����Ű�� �ִ� ����
    {
        C_Data.NpcName_Label_obj.transform.position = Camera.main.WorldToScreenPoint(I_Data.NameLabel_Zone.position);
    }
    private void OnMouseExit() //���콺�� ���� ���� ��
    {
        Outline_Unactive(); //�ƿ����� ����

        //�̸� �� ����
        C_Data.NpcName_Label_obj.SetActive(false);
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
                    Connect_Window_Individual();

                    b = false;
                }
                yield return null;
            }
            C_Data.NpcTalk_Window_obj.SetActive(true);
            C_Data.NpcTalk_Window_obj.GetComponent<NpcTalk_Window>().Talking(I_Data.Name); //�λ�
        }
    }

    public void Child_Start_Setting() // �ڽ� ��ũ��Ʈ�� Start()���� �������� ����ϴ� ����
    {
        C_Data.NpcName_Label_obj = NpcName_Label.Inst.gameObject;
        C_Data.NpcTalk_Window_obj = NpcTalk_Window.Inst.gameObject;
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
        NpcTalk_Window temp = C_Data.NpcTalk_Window_obj.GetComponent<NpcTalk_Window>();
        //�̸� ����
        temp.Name.text = I_Data.Name;

        //������ ���� = �̸��� ���� �ش� �����ʸ� Ȱ��ȭ �������� ��Ȱ��ȭ
        for (int i = 0; i < temp.Npc_Profiles.Length; i++)
        {
            if (temp.Npc_Profiles[i].name == gameObject.name)
            {
                temp.Npc_Profiles[i].SetActive(true);
            }
            else
            {
                temp.Npc_Profiles[i].SetActive(false);
            }
        }
        //�λ� ����
        temp.SaveText = I_Data.Greetings;
        //NpcIcon ����
        temp.Npc_Icon = I_Data.Npc_Icon;
    }

    public virtual void Connect_Window_Individual()
    {
    }

    public void Talk_Start() //��ȭ ����
    {
        //���콺�� ��ȣ�ۿ� ����
        isTalking = true;
        //�ƿ����� ����
        Outline_Unactive();
        //�̸� �� ����
        C_Data.NpcName_Label_obj.SetActive(false);
    }

    //�÷��̾�� ��ȭ ���� �� ���� �ٶ󺸰� �ִ� �������� ���ư���
    public void Talk_End() //��ȭ ��
    {
        //���콺�� ��ȣ�ۿ� �۵�
        isTalking = false;
        //���� �ٶ󺸴� �������� ȸ��
        StartCoroutine(Rotating(C_Data.OrgForward, false));
    }


    //����� �Լ���
    public virtual void Outline_Active() // �ƿ����� ����
    {
        // �ڽ��� ������
    }

    public virtual void Outline_Unactive() // �ƿ����� ����
    {
        // �ڽ��� ������
    }

    public virtual void Event_Of_Child()
    {

    }
}
