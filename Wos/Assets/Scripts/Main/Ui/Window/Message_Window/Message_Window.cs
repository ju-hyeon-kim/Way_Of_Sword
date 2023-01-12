using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Message_Window : MonoBehaviour
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

    public void Get_Item(string ItemName, int price)
    {
        //���� �ؿ� �ִ� �޽��� �˻�
        for (int i = 0; i < myMessages.Length; i++)
        {
            if(myMessages[i].transform.position == Create_Area)
            {
                myMessages[i].GetChild(0).GetComponent<TMP_Text>().text = $"ȹ�� {ItemName} +{price}";
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
            if(myMessages[i].gameObject.activeSelf == true)
            {
                myMessages[i].gameObject.SetActive(false);
            }
        }
    }
}
