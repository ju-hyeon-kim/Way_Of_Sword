using TMPro;
using UnityEngine;

public class Quest_Request : MonoBehaviour
{
    public TMP_Text Q_Name;
    public TMP_Text Q_Explanation;
    public GameObject[] Q_Reword;
    public Manager_Quest Manager_Quest;
    public NpcTalk_Window NpcTalk_Window;

    Quest_Data myQD;

    public void Accept_Button() // ���� ��ư
    {
        //Sfx
        ClickSound();

        Manager_Quest.Change_Quest();
        NpcTalk_Window.Lock_or_Unlock_Button(1, true); //����Ʈ ��û ��ư Lock ����
        gameObject.SetActive(false);
    }

    public void Recept_Button() // ���� ��ư
    {
        //Sfx
        ClickSound();

        gameObject.SetActive(false);
    }

    void ClickSound()
    {
        Manager_Sound.Inst.SfxSource.OnPlay(0);
    }

    public void Input_QuestData(Quest_Data QD) // ����Ʈ ������ �Է�
    {
        myQD = QD;

        Q_Name.text = myQD.Name;
        Q_Explanation.text = myQD.Explanation;

        // ����Ʈ �������� ������ ���󽽷Կ� ����
        for (int i = 0; i < myQD.Reward.Length; i++)
        {
            GameObject obj = Instantiate(myQD.Reward[i], Q_Reword[i].transform) as GameObject;
            obj.transform.SetAsFirstSibling();

        }
        // ������ ������ �°� �������� ���� ������ ������ �޶���
        for (int i = myQD.Reward.Length; i < Q_Reword.Length; i++)
        {
            Q_Reword[i].SetActive(false);
        }
    }
}
