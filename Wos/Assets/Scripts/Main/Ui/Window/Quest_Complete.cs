using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Complete : MonoBehaviour
{
    public GameObject Effect;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Effect_Unactive()
    {
        Effect.SetActive(false);
    }

    public void Confirm_Button()
    {
        //���� ����

        //��þƿ��� ��ȭ�γѾ

        gameObject.SetActive(false);
    }
}
