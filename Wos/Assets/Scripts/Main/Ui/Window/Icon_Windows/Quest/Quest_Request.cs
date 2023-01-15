using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_Request : MonoBehaviour
{
    public void Accept_Button() // 수락 버튼
    {

    }

    public void Recept_Button() // 거절 버튼
    {
        gameObject.SetActive(false);
    }
}
