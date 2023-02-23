using UnityEngine;

public class Sword_Zone : MonoBehaviour
{
    public GmTalk_Window GmTalk_Window;
    public bool InPlayer = false;

    private void OnTriggerEnter(Collider obj)
    {
        GmTalk_Window.Talk.text = GmTalk_Window.ReadyContents[1].Content;
        InPlayer = true;
    }

    private void OnTriggerExit(Collider obj)
    {
        GmTalk_Window.Talk.text = GmTalk_Window.ReadyContents[0].Content;
        InPlayer = false;
    }
}
