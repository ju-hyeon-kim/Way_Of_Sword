using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxSource : MonoBehaviour
{
    public AudioClip[] SgmList;

    public void OnPlay(int sgmnum)
    {
        AudioSource AS = GetComponent<AudioSource>();
        AS.clip = SgmList[sgmnum];
        AS.Play();
    }
}
