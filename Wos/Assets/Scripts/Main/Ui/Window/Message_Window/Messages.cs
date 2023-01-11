using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Messages : MonoBehaviour
{
    public Transform[] myMessages;

    public Transform Teleport_Area;
    Vector3 Create_Area;

    void Start()
    {
        //gameObject.SetActive(false);

        Create_Area = myMessages[3].transform.position;
    }

    public void Unactive_Obj()
    {
        gameObject.SetActive(false);
    }

    public void Get_A()
    {
        //°¡Àå ¹Ø¿¡ ÀÖ´Â ¸Þ½ÃÁö °Ë»ç
        for (int i = 0; i < myMessages.Length; i++)
        {
            if(myMessages[i].transform.position == Create_Area)
            {
                myMessages[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "È¹µæ A";
                StartCoroutine(Up_Anim());
            }
        }
    }

    public void Get_B()
    {
        for (int i = 0; i < myMessages.Length; i++)
        {
            if (myMessages[i].transform.position == Create_Area)
            {
                myMessages[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "È¹µæ B";
                StartCoroutine(Up_Anim());
            }
        }
    }

    public void Get_C()
    {
        for (int i = 0; i < myMessages.Length; i++)
        {
            if (myMessages[i].transform.position == Create_Area)
            {
                myMessages[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "È¹µæ C";
                StartCoroutine(Up_Anim());
            }
        }
    }
    public void Get_D()
    {
        for (int i = 0; i < myMessages.Length; i++)
        {
            if (myMessages[i].transform.position == Create_Area)
            {
                myMessages[i].transform.GetChild(0).GetComponent<TMP_Text>().text = "È¹µæ D";
                StartCoroutine(Up_Anim());
            }
        }
    }

    IEnumerator Up_Anim()
    {
        float dist = 50f;
        while (dist > 0.0f)
        {
            float delta = 200f * Time.deltaTime; //½ºÇÇµå
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
    }


}
