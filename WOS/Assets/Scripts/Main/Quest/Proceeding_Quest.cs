using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Proceeding_Quest : MonoBehaviour
{
    public Quest_Data Quest_Data;

    public TMP_Text Quest_Name;
    public TMP_Text Quest_Content;

    private void Start()
    {
        Quest_Name.text = Quest_Data.Name;
        Quest_Content.text = Quest_Data.Content;
    }
}
