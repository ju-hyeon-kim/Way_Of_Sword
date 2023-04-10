using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoice : MonoBehaviour
{
    public AudioClip[] Voices;

    public void PlaySound(int num)
    {
        AudioSource AS = GetComponent<AudioSource>();
        AS.clip = Voices[num];
        AS.Play();
    }
}
