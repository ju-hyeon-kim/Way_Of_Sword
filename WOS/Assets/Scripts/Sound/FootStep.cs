using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public AudioSource myAudioSource;
    public AudioClip FootStepL;
    public AudioClip FootStepR;

    public void SoundFootStepL()
    {
        myAudioSource.clip = FootStepL;
        myAudioSource.Play();
    }

    public void SoundFootStepR()
    {
        myAudioSource.clip = FootStepR;
        myAudioSource.Play();
    }
}
