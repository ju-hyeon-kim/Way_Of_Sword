using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : CharacterProperty
{
    public GameObject target;
    [SerializeField]
    float moveSpeed = 10.0f;
    bool bFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFire(Vector3 dir)
    {

    }

    private void MoveFireBall()
    {
        if(target != null)
        {
            float delta = moveSpeed * Time.deltaTime;
            Vector3 dir = transform.forward;
            transform.Translate(dir * delta);
        }
    }
}
