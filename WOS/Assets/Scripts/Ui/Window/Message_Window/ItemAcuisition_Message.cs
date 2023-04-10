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
        // �������� Ÿ���� �˻��Ͽ� Xp�� ����� price�� ������ ��Ÿ�� �ٸ� Ÿ���� �������̶�� 1�� ������ ��Ÿ��
        ItemType ItemType = Item.myData.ItemType;
        if (ItemType == ItemType.Xp || ItemType == ItemType.Gold)
        {
            Quantity = Item.myData.SellPrice;
        }
        Messages_Setting(Item.myData.Name, Quantity);
    }

    public void Get_Gold(int gold)
    {
        Messages_Setting("ȹ�� ���", gold);
    }

    public void Get_Xp(int xp)
    {
        Messages_Setting("ȹ�� ����ġ", xp);
    }

    void Messages_Setting(string name, int Quantity)
    {
        //���� �ؿ� �ִ� �޽��� �˻�
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
            float delta = 200f * Time.deltaTime; //���ǵ�
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

        yield return new WaitForSeconds(2.0f); // �����ð� �Ŀ� �����

        for (int i = 0; i < myMessages.Length; i++)
        {
            if (myMessages[i].gameObject.activeSelf == true)
            {
                myMessages[i].gameObject.SetActive(false);
            }
        }
    }
}