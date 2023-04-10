using TMPro;
using UnityEngine;

public class Quest_Complete : MonoBehaviour
{
    public TMP_Text Q_Name;
    public GameObject[] Q_Reword;
    public GameObject Effect;
    public Status_Tap Status;
    public NpcTalk_Window NpcTalk_Window;
    public Manager_Quest Manager_Quest;

    public void Effect_Unactive()
    {
        Effect.SetActive(false);
    }

    public void Confirm_Button()
    {
        //Sfx
        Manager_Sound.Inst.SfxSource.OnPlay(0);

        //���� ����
        for (int i = 0; i < 3; i++)
        {
            if (Q_Reword[i].transform.childCount > 2) // �������� ���� ����
            {
                Item_2D Item = Q_Reword[i].transform.GetChild(0).GetComponent<Item_2D>(); // Icon ������Ʈ ����
                Dont_Destroy_Data.Inst.Inventory_Window.PutItem(Item);
            }
        }

        //���� ����Ʈ�� ����
        Manager_Quest.None_Qeust();

        //����Ʈ ��û ��ư�� Lock ����
        NpcTalk_Window.Lock_or_Unlock_Button(1, false);

        gameObject.SetActive(false);
    }
}
