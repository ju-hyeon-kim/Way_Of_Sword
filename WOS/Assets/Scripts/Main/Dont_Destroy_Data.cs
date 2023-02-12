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

    [Header("-----Windows-----")]
    public Map_Window Map_Window;
    public ItemData_Windows ItemData_Windows;
    public Inventory_Window Inventory_Window;
    public NpcTalk_Window NpcTalk_Window;
    public Battle_Window Battle_Window;
    public Transform Label_Windows;

    [Header("-----Etc-----")]
    public Manager_Cams Manager_Cams;
    public Manager_Quest Manager_Quest;
    public Transform Canvas;
    public Transform Player;
    public Transform Unactive_Area;

    [HideInInspector]
    public Transform myPlaceManager; // ���̵��� ���Ŵ����� �˾Ƽ� ������ ��

    public void Start_Setting(Transform PlaceManager)
    {
        myPlaceManager = PlaceManager;

        Manager_SaveLode.Inst.JsonReady();
        Manager_SaveLode.Inst.JsonLoad();

        Manager_Cams.Start_Setting();
        Manager_Quest.Start_Setting(PlaceManager);
    }
}
