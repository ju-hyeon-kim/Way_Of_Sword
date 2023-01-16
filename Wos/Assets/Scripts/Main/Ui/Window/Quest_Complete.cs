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
        //보상 적용
        for(int i = 0; i < 3; i++)
        {
            if (Q_Reword[i].transform.GetChild(0).childCount > 0)
            {
                Icon Icon = Q_Reword[i].transform.GetChild(0).GetChild(0).GetComponent<Icon>(); // Icon 컴포넌트 저장
                string ItemName = Icon.Item_Data.Name; // 아이템의 이름 가져오기

                // 아이템의 타입을 검사하여 Xp나 골드라면 price가 수량을 나타냄 다른 타입의 아이템이라면 1로 수량을 나타냄
                Item.Type ItemType = Icon.Item_Data.ItemType; 
                int price = 1;
                if(ItemType == Item.Type.Xp)
                {
                    price = Icon.Item_Data.Price;
                    //XP -> 스테이터스에 적용
                    Status.Level.Get_Xp(price);
                }
                else if(ItemType == Item.Type.Gold)
                {
                    price = Icon.Item_Data.Price;
                    //Gold -> 보유골드에 적용
                }
                else // 아이템타입이 XP나 골드가 아님
                {
                    //Item -> 인벤토리에 적용
                }
                Message_Window.Get_Item(ItemName, price);
            }
        }

        //PQ에 컴플리트 호출
        Manager_Quest.Quest_Complete();

        //퀘스트 신청 버튼 활성화
        NpcTalk_Window.Unlock_Button(1);

        //퀘스트 매니저의 다음 퀘스트를 퀘스트 신청 버튼에 연동
        Manager_Quest.Give_Quest_To_Request();

        gameObject.SetActive(false);
    }
}
