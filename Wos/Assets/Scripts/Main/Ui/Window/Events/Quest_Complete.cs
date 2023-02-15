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
    public Status_Tap Status;
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
            if (Q_Reword[i].transform.childCount > 2) // �������� ���� ����
            {
                Item_2D Item = Q_Reword[i].transform.GetChild(0).GetComponent<Item_2D>(); // Icon ������Ʈ ����
                

                // �������� Ÿ���� �˻��Ͽ� Xp�� ����� price�� ������ ��Ÿ�� �ٸ� Ÿ���� �������̶�� 1�� ������ ��Ÿ��
                ItemType ItemType = Item.myData.ItemType; 
                int price = 1;
                if(ItemType == ItemType.Xp)
                {
                    price = Item.myData.Price;
                    //XP -> �������ͽ��� ����
                }
                else if(ItemType == ItemType.Gold)
                {
                    price = Item.myData.Price;
                    //Gold -> ������忡 ����
                }
                else // ������Ÿ���� XP�� ��尡 �ƴ�
                {
                    //Item -> �κ��丮�� ����
                    Dont_Destroy_Data.Inst.Inventory_Window.Put_Item(Item);
                }
                string ItemName = Item.myData.Name; // �������� �̸� ��������
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
