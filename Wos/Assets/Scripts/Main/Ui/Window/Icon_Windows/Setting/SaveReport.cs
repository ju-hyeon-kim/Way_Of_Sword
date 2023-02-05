using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveReport : MonoBehaviour
{
    public TMP_Text QuestName;

    public void OnSave()
    {
        QuestName.text = Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Name;
    }
}
