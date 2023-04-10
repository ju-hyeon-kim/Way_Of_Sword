using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CustomTool : MonoBehaviour
{

    public AudioClip Bclick;
    public AudioMixer Sfx;

    [ContextMenu("함수실행")]
    void tool()
    {
        Exit_Button[] EBs = FindObjectsOfType<Exit_Button>();
        for(int i = 0; i < EBs.Length; i++)
        {
            EBs[i].AddComponent<AudioSource>();
            EBs[i].GetComponent<AudioSource>().clip = Bclick;
            EBs[i].GetComponent<AudioSource>().playOnAwake = false;
            EBs[i].GetComponent<AudioSource>().volume = 0.5f;
        }
    }
}
