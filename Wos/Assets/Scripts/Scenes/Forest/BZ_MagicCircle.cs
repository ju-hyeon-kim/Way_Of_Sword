using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BZ_MagicCircle : MonoBehaviour
{
    public Animator myEntrance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            myEntrance.SetTrigger("Open");
            gameObject.SetActive(false);
        }
    }
}
