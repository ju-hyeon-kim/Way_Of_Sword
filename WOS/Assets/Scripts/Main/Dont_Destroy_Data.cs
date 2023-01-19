using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_Data : MonoBehaviour
{
    public Manager_Cams Manager_Cams;

    void Awake()
    {
        DontDestroyOnLoad(this); // ����ȯ �� �ı����� ����
    }

    public void Start_Setting()
    {
        Manager_Cams.Start_Setting();
        Manager_Quest.Inst.Start_Setting();
    }
}
