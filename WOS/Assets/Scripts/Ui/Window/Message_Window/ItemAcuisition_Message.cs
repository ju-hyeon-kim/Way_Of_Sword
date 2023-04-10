using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemAcuisition_Message : MonoBehaviour
{
    public Transform[] myMessages;
    public Transform Teleport_Area;
    Vector3 Create_Area;

    void Start()
    {
        Create_Area = myMessages[3].transform.position;
        for (int i = 0; i < myMessages.Length; i++)
        {
            myMessages[i].gameObject.SetActive(false);
        }
    }

    public void Get_Item(Item_2D Item, int Quantity)
    {
        // 아이템의 타입을 검사하여 Xp나 골드라면 price가 수량을 나타냄 다른 타입의 아이템이라면 1로 수량을 나타냄
        ItemType ItemType = Item.myData.ItemType;
        if (ItemType == ItemType.Xp || ItemType == ItemType.Gold)
        {
            Quantity = Item.myData.SellPrice;
        }
        Messages_Setting(Item.myData.Name, Quantity);
    }

    public void Get_Gold(int gold)
    {
        Messages_Setting("획득 골드", gold);
    }

    public void Get_Xp(int xp)
    {
        Messages_Setting("획득 경험치", xp);
    }

    void Messages_Setting(string name, int Quantity)
    {
        //가장 밑에 있는 메시지 검사
        for (int i = 0; i < myMessages.Length; i++)
        {
            if (myMessages[i].transform.position == Create_Area) 
            {
                myMessages[i].GetChild(0).GetComponent<TMP_Text>().text = $"{name} +{Quantity}";
                myMessages[i].gameObject.SetActive(true);
                StartCoroutine(Up_Anim());
            }
        }
    }

    IEnumerator Up_Anim()
    {
        float dist = 50f;

        while (dist > 0.0f)
        {
            float delta = 200f * Time.deltaTime; //스피드
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            for (int i = 0; i < myMessages.Length; i++)
            {
                myMessages[i].Translate(Vector3.up * delta);
            }
            yield return null;
        }

        for (int i = 0; i < myMessages.Length; i++)
        {
            if (myMessages[i].position.y > Teleport_Area.position.y)
            {
                myMessages[i].position = Create_Area;
            }
        }

        yield return new WaitForSeconds(2.0f); // 일정시간 후에 사라짐

        for (int i = 0; i < myMessages.Length; i++)
        {
            if (myMessages[i].gameObject.activeSelf == true)
            {
                myMessages[i].gameObject.SetActive(false);
            }
        }
    }
}