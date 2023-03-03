using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [Header("-----Npc-----")]
    public string Name;
    [Multiline]
    public string Greetings; // �λ�
    public Transform NameLabel_Zone;

    protected NpcTalk_Window NpcTalk_Window;
    MainCam_Controller MainCam;

    bool isTalking = false; //���� ��ȭ���� üũ�ϴ� bool ��
    Vector3 saveForward = Vector3.zero; 

    #region ���콺 �����ǰ� ��ȣ�ۿ��ϴ� �Լ�
    private void OnMouseEnter() //���콺�� ���� ����� ��
    {
        if (!isTalking) // ��ȭ���� �ƴ϶��
        {
            //�ƿ����� �ѱ�
            Outline_SetActive(true);

            //�̸� �� �ѱ�
            NpcName_Label.Inst.gameObject.SetActive(true);
            NpcName_Label.Inst.GetComponentInChildren<TMP_Text>().text = Name;
        }
    }
    private void OnMouseOver() //���콺�� Npc�� ����Ű�� �ִ� ����
    {
        NpcName_Label.Inst.transform.position = Camera.main.WorldToScreenPoint(NameLabel_Zone.position);
    }
    private void OnMouseExit() //���콺�� ���� ���� ��
    {
        Outline_SetActive(false); //�ƿ����� ����

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
            MainCam.ChangeView(transform);
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
                if (MainCam.Talk_Ready)
                {
                    Connect_Window_Common();

                    b = false;
                }
                yield return null;
            }
            NpcTalk_Window.gameObject.SetActive(true);
            NpcTalk_Window.Talking(this); //�λ�
        }
    }

    public void Child_Start_Setting() // �ڽ� ��ũ��Ʈ�� Start()���� �������� ����ϴ� ����
    {
        MainCam = Camera.main.transform.parent.GetComponent<MainCam_Controller>();
    }

    public void Reaction(GameObject Player) // �÷��̾ ���� �ɸ� ���׼�
    {
        NpcTalk_Window = Dont_Destroy_Data.Inst.NpcTalk_Window;
        MainCam = Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller;

        //�÷��̾� ������ ȸ��
        StartCoroutine(Rotating(Player.transform.position, true));

        Child_Reaction(Player);
    }

    public void Connect_Window_Common() // NpcTalk_Widow�� Npc_Data�� ���� (�������� ��ҵ���)
    {
        //�̸� ����
        NpcTalk_Window.myTMP_Texts[0].text = Name; // Npc�� �̸� ����

        //������ ���� = �̸��� ���� �ش� �����ʸ� Ȱ��ȭ �������� ��Ȱ��ȭ
        for (int i = 0; i < NpcTalk_Window.Npc_Profiles.Length; i++)
        {
            if (NpcTalk_Window.Npc_Profiles[i].name == gameObject.name)
            {
                NpcTalk_Window.Npc_Profiles[i].SetActive(true);
            }
            else
            {
                NpcTalk_Window.Npc_Profiles[i].SetActive(false);
            }
        }
    }

    public void Talk_Start() //��ȭ ����
    {
        //���� �ٶ󺸴� ���� ����
        saveForward = this.transform.localPosition + this.transform.forward;
        //���콺�� ��ȣ�ۿ� ����
        isTalking = true;
        //�ƿ����� ����
        Outline_SetActive(false);
        //�̸� �� ����
        NpcName_Label.Inst.gameObject.SetActive(false);
    }

    //�÷��̾�� ��ȭ ���� �� ���� �ٶ󺸰� �ִ� �������� ���ư���
    public void Talk_End() //��ȭ ��
    {
        //���콺�� ��ȣ�ۿ� �۵�
        isTalking = false;
        //���� �ٶ󺸴� �������� ȸ��
        StartCoroutine(Rotating(saveForward, false));
    }

    public virtual void Outline_SetActive(bool b) { } // �ƿ����� ����
    public virtual void Child_Reaction(GameObject Player) { } // �ڽĸ��� �ٸ� ���׼�

    public void Buttons_Setting() //��ư�� ����
    {
        Button_0and1_Set();
        Button2_Set();
    }

    public virtual void Button_0and1_Set() { } // ����Ʈ�� ���� ����

    public void Button2_Set() // ���ư��� ��ư
    {
        NpcTalk_Window.Buttons[2].GetComponent<Button>().onClick.RemoveAllListeners();
        NpcTalk_Window.Buttons[2].GetComponent<Button>().onClick.AddListener(Button2_OnClick);
        NpcTalk_Window.Buttons[2].SetActive(true);
    }

    public void Button2_OnClick() // ���ư���
    {
        //��ư ��Ȱ��ȭ
        for (int i = 0; i < NpcTalk_Window.Buttons.Length; i++)
        {
            NpcTalk_Window.Buttons[i].SetActive(false);
        }
        NpcTalk_Window.gameObject.SetActive(false);
        // �ڽĵ��� �޶����� �ɼ�
        Button2_OnClick_ofChild();
        // ī�޶� ���� �������
        NpcTalk_Window.MainCam.ReturnView(true);
    }

    public virtual void Button2_OnClick_ofChild() { }
}
