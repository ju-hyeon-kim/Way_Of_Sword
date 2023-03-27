using TMPro;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    public TMP_Text Line;
    bool isEndAnim = false;

    public void ShoutAnim(string line, int num)
    {
        isEndAnim = false;
        Line.text = line;
        GetComponent<Animator>().SetTrigger($"Shout{num}");
    }

    public bool Get_isEndAnim()
    {
        return isEndAnim;
    }

    public void isEndAnim_SetTrue() // AnimEvent
    {
        isEndAnim = true;
    }
}
