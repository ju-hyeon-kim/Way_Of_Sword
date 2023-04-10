using System;
using System.IO;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_SaveLode : Singleton<Manager_SaveLode>
{
    public bool isLoad = true;

    public void JsonLoad(int pagenum) // 로드: 로드한 데이터를 게임에 적용
    {
        Debug.Log("제이슨 로드");
        string loadJson = File.ReadAllText(Get_Path(pagenum));
        SaveData savedata = JsonUtility.FromJson<SaveData>(loadJson);
        Dont_Destroy_Data.Inst.Manager_Quest.LoadQuest(savedata.QuestName);
        Dont_Destroy_Data.Inst.Manager_Gold.NowGold = savedata.Gold;
        Dont_Destroy_Data.Inst.Player.GetComponent<Player_Stat>().Level = savedata.Level;

        Dont_Destroy_Data.Inst.Inventory_Window.Load_ItemData(savedata);
    }

    public void JsonSave(SavePage savepage)
    {
        string json = JsonUtility.ToJson(Make_NewSaveData(savepage), true);
        File.WriteAllText(Get_Path(savepage.pagenum), json);
    }

    SaveData Make_NewSaveData(SavePage savepage) // 저장
    {
        SaveData savedata  = new SaveData();
        savedata.QuestName = Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Name;
        savedata.Gold = Dont_Destroy_Data.Inst.Manager_Gold.NowGold;
        savedata.Time = savepage.Time.text;
        savedata.Place = SceneManager.GetActiveScene().name;
        savedata.Level = Dont_Destroy_Data.Inst.Player.GetComponent<Player_Stat>().Level;
        Dont_Destroy_Data.Inst.Inventory_Window.Save_ItemData(savedata);
        return savedata;
    }

    string Get_Path(int pagenum)
    {
        //string path = Path.Combine(Application.dataPath + "/SaveFile/", $"SaveFile{pagenum}.json");
        string path = Path.Combine(Application.dataPath, $"SaveFile{pagenum}.json");
        return path;
    }

    public bool isSaveFile_Exists(int pagenum)
    {
        if (File.Exists(Get_Path(pagenum))) // pagenum에 해당하는 저장파일이 있으면
        {
            return true;
        }
        return false;
    }

    public SaveData Get_SaveData(int pagenum)
    {
        string loadJson = File.ReadAllText(Get_Path(pagenum));
        SaveData savedata = JsonUtility.FromJson<SaveData>(loadJson);
        return savedata;
    }
}
