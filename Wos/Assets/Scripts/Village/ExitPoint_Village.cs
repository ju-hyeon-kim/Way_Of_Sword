using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint_Village : MonoBehaviour
{
    Map_Window Map_Window;

    private void Start()
    {
        Map_Window = Dont_Destroy_Data.Inst.Map_Window;
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        Map_Window.NowQuest_Check();
        Map_Window.gameObject.SetActive(true);
    }
}
