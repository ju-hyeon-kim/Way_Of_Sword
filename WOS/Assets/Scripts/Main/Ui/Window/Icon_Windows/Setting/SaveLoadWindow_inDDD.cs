using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadWindow_inDDD : SaveLoad_Window
{
    public void LodeButton() // OnClick 바인딩
    {
        Question_Window QWindow = Dont_Destroy_Data.Inst.Question_Window;
        string contant = "이전 여행의 기록을 불러오시겠습니까?";
        QWindow.WindowSetting(contant, Ybutton_ofLode);
        QWindow.gameObject.SetActive(true);
    }

    void Ybutton_ofLode() // OnClick 바인딩
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
        string contant = "지금까지의 여행을 기록하시겠습니까?";
        QWindow.WindowSetting(contant, Ybutton_ofSave);
        QWindow.gameObject.SetActive(true);
    }

    void Ybutton_ofSave() // OnClick 바인딩
    {
        //JsonSave
        int pagenum = SaveLode_Window.Now_PageNum;
        Manager_SaveLode.Inst.JsonSave(SaveLode_Window.SavePages[pagenum - 1]);
        SaveLode_Window.SavePages[pagenum - 1].GetComponent<SavePage>().OnSave();

        // "기록이 완료되었습니다."
        Notice_Window NWindow = Dont_Destroy_Data.Inst.Notice_Window;
        string contant = "기록이 완료되었습니다!";
        NWindow.WindowSetting(contant);
        NWindow.gameObject.SetActive(true);
    }
}
