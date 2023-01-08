using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk_Window : MonoBehaviour
{
    #region �̱��� ���� + Awake()
    private static NpcTalk_Window Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
    }

    public static NpcTalk_Window Inst
    {
        get
        {
            if (Instence == null) // �ٸ� ������Ʈ�� Awake()���� Inst�� ȣ���� ���
            {
                return null;
            }
            return Instence;
        }
    }
    #endregion

    public GameObject[] Npc_Profiles;
    public GameObject[] Buttons;
    public GameObject[] Events;

    public TMP_Text Name;
    public TMP_Text Talk;
    public MainCam_Controller MainCam;
    public GameObject Lock;
    public GameObject Messages;
    public Image XP_Bar;
    public TMP_Text XP_Readings;
    public GameObject Npc_Icon = null;
    public Quest_SubWindow Quest_SubWindow;

    public string SaveText = "";
    string SaveString = "";
    string Target_Npc = "";

    private void Start()
    {
        for(int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void Talking(string Npc_Name)
    {
        Target_Npc = Npc_Name;
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        for (int i = 0; i < SaveText.Length; ++i)
        {
            SaveString += SaveText[i];
            Talk.text = SaveString;
            yield return new WaitForSeconds(0.1f); // 0.1�ʴ� �� ���� Ÿ����
        }
        //Save strings �ʱ�ȭ
        SaveText = "";
        SaveString = "";

        //��ư Ȱ��ȭ
        for(int i = 0; i < Buttons.Length; i++)
        {
            
            switch(Target_Npc)
            {
                case "����":
                    i = 2; // ���ư��� ��ư�� Ȱ��ȭ
                    break;
                case "��þ�":
                    //��þ� ��ư ����
                    Lucia_Setting();
                    break;
            }
            Buttons[i].SetActive(true); // ���ư��� ��ư Ȱ��ȭ�� ����
        }
    }

    public void On_GobackButton()
    {
        //��ư ��Ȱ��ȭ
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].SetActive(false);
        }
        this.gameObject.SetActive(false);
        // ī�޶� ���� �������
        MainCam.ReturnView();
    }

    void Lucia_Setting()
    {
        //0�� ��ư
        Buttons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ �Ϸ� 1��";
        Buttons[0].GetComponent<Button>().onClick.AddListener(QuestComplete_Button);
        //1�� ��ư
        Buttons[1].GetComponent<Image>().color = Color.gray;
        Buttons[1].transform.GetChild(0).GetComponent<TMP_Text>().text = "����Ʈ ��û";
        Lock.SetActive(true);
    }

    void QuestComplete_Button()
    {
        Events[0].SetActive(true);
        //�ִϸ��̼�
        Events[0].GetComponent<Animator>().SetBool("Open", true);
        //���� ����
        Messages.SetActive(true);
        XP_Bar.fillAmount = 0;
        XP_Bar.fillAmount += 50.0f * 0.01f;
        XP_Readings.text = "(50/100)";
        //Npc������ ��Ȱ��ȭ
        Npc_Icon.SetActive(false);
        //����Ʈ ���� ������ ����
        Quest_SubWindow.Quest_Remove(0);
    }
}
