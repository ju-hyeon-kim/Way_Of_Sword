using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadWindow_inDDD : SaveLoad_Window
{
    public void LodeButton() // OnClick ���ε�
    {
        Question_Window QWindow = Dont_Destroy_Data.Inst.Question_Window;
        string contant = "���� ������ ����� �ҷ����ðڽ��ϱ�?";
        QWindow.WindowSetting(contant, Ybutton_ofLode);
        QWindow.gameObject.SetActive(true);
    }

    void Ybutton_ofLode() // OnClick ���ε�
    {
        int slotnum = Now_PageNum;
        Dont_Destroy_Data.Inst.LoadSlotNum = slotnum;
        Dont_Destroy_Data.Inst.isLoad = true;
        string place = Manager_SaveLode.Inst.Get_SaveData(slotnum).Place;
        Manager_SceneChange.Inst.ChangeScene(place);
        this.gameObject.SetActive(false);
    }

    public SaveLoad_Window SaveLode_Window;

    public void SaveButton()
    {
        Question_Window QWindow = Dont_Destroy_Data.Inst.Question_Window;
        string contant = "���ݱ����� ������ ����Ͻðڽ��ϱ�?";
        QWindow.WindowSetting(contant, Ybutton_ofSave);
        QWindow.gameObject.SetActive(true);
    }

    void Ybutton_ofSave() // OnClick ���ε�
    {
        //JsonSave
        int pagenum = SaveLode_Window.Now_PageNum;
        Manager_SaveLode.Inst.JsonSave(SaveLode_Window.SavePages[pagenum - 1]);
        SaveLode_Window.SavePages[pagenum - 1].GetComponent<SavePage>().OnSave();

        // "����� �Ϸ�Ǿ����ϴ�."
        Notice_Window NWindow = Dont_Destroy_Data.Inst.Notice_Window;
        string contant = "����� �Ϸ�Ǿ����ϴ�!";
        NWindow.WindowSetting(contant);
        NWindow.gameObject.SetActive(true);
    }
}
