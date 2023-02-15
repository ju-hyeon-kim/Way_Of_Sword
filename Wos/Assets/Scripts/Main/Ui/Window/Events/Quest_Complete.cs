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
        //보상 적용
        for(int i = 0; i < 3; i++)
        {
            if (Q_Reword[i].transform.childCount > 2) // 아이템이 있을 때만
            {
                Item_2D Item = Q_Reword[i].transform.GetChild(0).GetComponent<Item_2D>(); // Icon 컴포넌트 저장
                

                // 아이템의 타입을 검사하여 Xp나 골드라면 price가 수량을 나타냄 다른 타입의 아이템이라면 1로 수량을 나타냄
                ItemType ItemType = Item.myData.ItemType; 
                int price = 1;
                if(ItemType == ItemType.Xp)
                {
                    price = Item.myData.Price;
                    //XP -> 스테이터스에 적용
                }
                else if(ItemType == ItemType.Gold)
                {
                    price = Item.myData.Price;
                    //Gold -> 보유골드에 적용
                }
                else // 아이템타입이 XP나 골드가 아님
                {
                    //Item -> 인벤토리에 적용
                    Dont_Destroy_Data.Inst.Inventory_Window.Put_Item(Item);
                }
                string ItemName = Item.myData.Name; // 아이템의 이름 가져오기
                Message_Window.Get_Item(ItemName, price);
            }
        }

        //현재 퀘스트는 없음
        Manager_Quest.None_Qeust();

        //퀘스트 신청 버튼의 Lock 해제
        NpcTalk_Window.Lock_or_Unlock_Button(1,false);

        gameObject.SetActive(false);
    }
}
