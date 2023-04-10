using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZone_Door : MonoBehaviour
{
    public void OnMovingSound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void OffMovingSound()
    {
        GetComponent<AudioSource>().Stop();
    }
}
