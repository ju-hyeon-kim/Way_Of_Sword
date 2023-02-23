using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int QuestNum;
}

public class Manager_SaveLode : Singleton<Manager_SaveLode>
{
    string path;

    public void JsonReady()
    {
        path = Path.Combine(Application.dataPath + "/SaveFile/", "SaveFile.json");
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (File.Exists(path)) //저장된 파일이 있으면
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            Dont_Destroy_Data.Inst.Manager_Quest.Quest_Num = saveData.QuestNum;
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        saveData.QuestNum = Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Quest_Number;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(path, json);
    }
}
