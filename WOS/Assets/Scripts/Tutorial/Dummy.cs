using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Transform Player;
    public Manager_Tutorial Manager_Tutorial;

    Vector3 PtoD;
    float time = 0f;

    public void OnDamage()
    {
        StartCoroutine(Damage_Anim());
    }

    IEnumerator Damage_Anim()
    {
        GetComponent<Animator>().SetTrigger("Damage");
        PtoD = Player.position - transform.position;
        PtoD.Normalize();

        while (time < 1.5f)
        {
            time += Time.deltaTime;
            GetComponent<Animator>().SetFloat("x", PtoD.x);
            GetComponent<Animator>().SetFloat("z", PtoD.z);
            yield return null;
        }

        time = 0;
        if(Manager_Tutorial.BasicAttack_end == false)
        {
            Manager_Tutorial.BasicAttack_end = true;
        }
    }

}
