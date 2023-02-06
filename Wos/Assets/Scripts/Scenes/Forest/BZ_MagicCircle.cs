using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZ_MagicCircle : MonoBehaviour
{
    public Animator myEntrance;
    public Manager_Forest myManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myManager.Spawn_BeatleKing();
            myEntrance.SetTrigger("Open");
            gameObject.SetActive(false);
        }
    }
}
