using TMPro;
using UnityEngine;

public class Gm_Message : MonoBehaviour
{
    [Multiline]
    public string[] Lines;
    public TMP_Text Line;

    public void ShowMessage(int linenum)
    {
        Line.text = Lines[linenum];
    }
}