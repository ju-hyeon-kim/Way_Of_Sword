using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame_Window : SaveLoad_Window
{
    [Header("-----LoadGame_Window-----")]
    public Question_Window Question_Window;

    public void LoadButton()
    {
        Debug.Log("�ε��ư�� �������");
        string contant = "���� ������ ����� �ҷ����ðڽ��ϱ�?";
        Question_Window.WindowSetting(contant, YesButton_OnClick);
        Question_Window.gameObject.SetActive(true);
    }

    void YesButton_OnClick() // OnClick ���ε�
    {
        int slotnum = Now_PageNum;
        Dont_Destroy_Data.Inst.LoadSlotNum = slotnum;
        Dont_Destroy_Data.Inst.isLoad = true;
        string place = Manager_SaveLode.Inst.Get_SaveData(slotnum).Place;
        Manager_SceneChange.Inst.ChangeScene(place);
        this.gameObject.SetActive(false);
    }
}
