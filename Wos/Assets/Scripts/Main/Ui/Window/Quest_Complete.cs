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
                Icon Icon = Q_Reword[i].transform.GetChild(0).GetChild(0).GetComponent<Icon>(); // Icon ������Ʈ ����
                string ItemName = Icon.Item_Data.Name; // �������� �̸� ��������

                // �������� Ÿ���� �˻��Ͽ� Xp�� ����� price�� ������ ��Ÿ�� �ٸ� Ÿ���� �������̶�� 1�� ������ ��Ÿ��
                Item.Type ItemType = Icon.Item_Data.ItemType; 
                int price = 1;
                if(ItemType == Item.Type.Xp)
                {
                    price = Icon.Item_Data.Price;
                    //XP -> �������ͽ��� ����
                    Status.Level.Get_Xp(price);
                }
                else if(ItemType == Item.Type.Gold)
                {
                    price = Icon.Item_Data.Price;
                    //Gold -> ������忡 ����
                }
                else // ������Ÿ���� XP�� ��尡 �ƴ�
                {
                    //Item -> �κ��丮�� ����
                }
                Message_Window.Get_Item(ItemName, price);
            }
        }

        //PQ�� ���ø�Ʈ ȣ��
        Manager_Quest.Quest_Complete();

        //����Ʈ ��û ��ư Ȱ��ȭ
        NpcTalk_Window.Unlock_Button(1);

        //����Ʈ �Ŵ����� ���� ����Ʈ�� ����Ʈ ��û ��ư�� ����
        Manager_Quest.Give_Quest_To_Request();

        gameObject.SetActive(false);
    }
}
