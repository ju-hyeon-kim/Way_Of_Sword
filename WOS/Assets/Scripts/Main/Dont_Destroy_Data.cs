using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_Data : MonoBehaviour
{
    #region �̱��� ���� + Awake()
    private static Dont_Destroy_Data Instence = null;

    private void Awake()
    {
        if (Instence == null)
        {
            Instence = this;
        }
        DontDestroyOnLoad(this);
    }

    public static Dont_Destroy_Data Inst
    {
        get
        {
            if (Instence == null) // �ٸ� ������Ʈ�� Awake()���� Inst�� ȣ���� ���
            {
                return null;
            }
            return Instence;
        }
    }
    #endregion

    public Transform myPlaceManager; // ���̵��� ���Ŵ����� �˾Ƽ� ������ ��
    public Manager_Cams Manager_Cams;
    public Manager_Quest Manager_Quest;
    public Map_Window Map_Window;
    public ItemData_Windows ItemData_Windows;
    public Transform Canvas;
    public Transform Player;
    public Transform Battle_Window;
    public Transform Rabel_Windows;

    public void Start_Setting()
    {
        Manager_SaveLode.Inst.JsonReady();
        Manager_SaveLode.Inst.JsonLoad();

        Manager_Cams.Start_Setting();
        Manager_Quest.Start_Setting();
    }
}
