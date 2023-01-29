using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AI_Perception : MonoBehaviour
{
    public UnityEvent<Transform> FindTarget = default;
    public UnityEvent LostTarget = default;
    public LayerMask enemyMask = default;
    public Transform myTarget = null;

    void Start()
    {  
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (myTarget != null) return;
        if((enemyMask & 1 << other.gameObject.layer) != 0)
        {
            myTarget = other.transform;
            FindTarget?.Invoke(myTarget);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(myTarget == other.transform)
        {
            myTarget = null;
            LostTarget?.Invoke();
        }
    }
}
