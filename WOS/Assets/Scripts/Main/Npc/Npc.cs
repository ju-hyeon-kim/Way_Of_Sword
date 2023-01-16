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
    IEnumerator Rotating(Vector3 pos, bool B) // B = true = ��ȭ���� // B = false = ��ȭ ��
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
            C_Data.NpcTalk_Window.gameObject.SetActive(true);
            C_Data.NpcTalk_Window.Talking(this); //�λ�
        }
    }

    public void Child_Start_Setting() // �ڽ� ��ũ��Ʈ�� Start()���� �������� ����ϴ� ����
    {
        C_Data.MainCam = Camera.main.transform.parent.GetComponent<MainCam_Controller>();
        C_Data.OrgForward = I_Data.myForward.position;
    }

    public void Reaction(GameObject Player) // �÷��̾ ���� �ɸ� ���׼�
    {
        C_Data.NpcTalk_Window = Player.GetComponent<Player_Main>().NpcTalk_Window;
        //�÷��̾� ������ ȸ��
        StartCoroutine(Rotating(Player.transform.position, true));
    }

    public void Connect_Window_Common() // NpcTalk_Widow�� Npc_Data�� ���� (�������� ��ҵ���)
    {
        //�̸� ����
        C_Data.NpcTalk_Window.myTMP_Texts[0].text = I_Data.Name; // Npc�� �̸� ����

        //������ ���� = �̸��� ���� �ش� �����ʸ� Ȱ��ȭ �������� ��Ȱ��ȭ
        for (int i = 0; i < C_Data.NpcTalk_Window.Npc_Profiles.Length; i++)
        {
            if (C_Data.NpcTalk_Window.Npc_Profiles[i].name == gameObject.name)
            {
                C_Data.NpcTalk_Window.Npc_Profiles[i].SetActive(true);
            }
            else
            {
                C_Data.NpcTalk_Window.Npc_Profiles[i].SetActive(false);
            }
        }
        //�λ� ����
        C_Data.NpcTalk_Window.SaveText = I_Data.Greetings;
        //NpcIcon ����
        C_Data.NpcTalk_Window.Npc_Icon = I_Data.Npc_Icon;
    }

    

    public void Talk_Start() //��ȭ ����
    {
        //���콺�� ��ȣ�ۿ� ����
        isTalking = true;
        //�ƿ����� ����
        Outline_Unactive();
        //�̸� �� ����
        NpcName_Label.Inst.gameObject.SetActive(false);
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
        C_Data.NpcTalk_Window.Buttons[2].GetComponent<Button>().onClick.AddListener(Button2_OnClick);
        C_Data.NpcTalk_Window.Buttons[2].SetActive(true);
    }

    public void Button2_OnClick() // ���ư���
    {
        //��ư ��Ȱ��ȭ
        for (int i = 0; i < C_Data.NpcTalk_Window.Buttons.Length; i++)
        {
            C_Data.NpcTalk_Window.Buttons[i].SetActive(false);
        }
        C_Data.NpcTalk_Window.gameObject.SetActive(false);
        // ī�޶� ���� �������
        C_Data.NpcTalk_Window.MainCam.ReturnView();
    }
}
