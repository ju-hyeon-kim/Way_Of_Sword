using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSource : MonoBehaviour
{
    public AudioClip[] BgmList;

    public void OnPlay(int bgmnum)
    {
        AudioSource AS = GetComponent<AudioSource>();
        AS.clip = BgmList[bgmnum];
        AS.Play();
    }
}
