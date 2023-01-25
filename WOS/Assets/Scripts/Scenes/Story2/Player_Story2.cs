using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Story2 : MonoBehaviour
{
    public float MoveSpeed = 1.0f;
    public bool isArrival = false;

    public void Movement(string CoName)
    {
        switch(CoName)
        {
            case "Move_Door":
                StartCoroutine(Move_Door());
                break;
        }
    }

    IEnumerator Move_Door()
    {
        float dist = 1.7f;

        GetComponent<Animator>().SetBool("Walk", true);
        while(dist > 0.0f)
        {
            float delta = MoveSpeed * Time.deltaTime;
            if (delta > dist)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(Vector3.right * delta, Space.World);
            yield return null;
        }

        GetComponent<Animator>().SetBool("Walk", false);
        isArrival = true; // µµÂø Çß´Ù.
    }
}
