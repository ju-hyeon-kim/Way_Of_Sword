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
        //보상 적용

        //루시아와의 대화로넘어감

        gameObject.SetActive(false);
    }
}
