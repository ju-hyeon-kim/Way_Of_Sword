using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_Complete : MonoBehaviour
{
    public TMP_Text Q_Name;
    public GameObject[] Q_Reword;
    public GameObject Effect;
    public Message_Window Message_Window;
    public Status Status;
    public NpcTalk_Window NpcTalk_Window;
    public Manager_Quest Manager_Quest;

    public void Effect_Unactive()
    {
        Effect.SetActive(false);
    }

    public void Confirm_Button()
    {
        //���� ����
        for(int i = 0; i < 3; i++)
        {
            if (Q_Reword[i].transform.GetChild(0).childCount > 0)
            {
                Item_2D Icon = Q_Reword[i].transform.GetChild(0).GetChild(0).GetComponent<Item_2D>(); // Icon ������Ʈ ����
                string ItemName = Icon.myData.Name; // �������� �̸� ��������

                // �������� Ÿ���� �˻��Ͽ� Xp�� ����� price�� ������ ��Ÿ�� �ٸ� Ÿ���� �������̶�� 1�� ������ ��Ÿ��
                ItemType ItemType = Icon.myData.ItemType; 
                int price = 1;
                if(ItemType == ItemType.Xp)
                {
                    price = Icon.myData.Price;
                    //XP -> �������ͽ��� ����
                    Status.Level.Get_Xp(price);
                }
                else if(ItemType == ItemType.Gold)
                {
                    price = Icon.myData.Price;
                    //Gold -> ������忡 ����
                }
                else // ������Ÿ���� XP�� ��尡 �ƴ�
                {
                    //Item -> �κ��丮�� ����
                }
                Message_Window.Get_Item(ItemName, price);
            }
        }

        //���� ����Ʈ�� ����
        Manager_Quest.None_Qeust();

        //����Ʈ ��û ��ư�� Lock ����
        NpcTalk_Window.Lock_or_Unlock_Button(1,false);

        gameObject.SetActive(false);
    }
}
