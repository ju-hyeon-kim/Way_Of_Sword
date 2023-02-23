using System.Collections;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public Transform Player;
    public Manager_Tutorial Manager_Tutorial;
    public HP_of_Dummy hp_of_dummy;
    public float maxHP = 100;
    public bool isDead = false;
    public bool Step_KillDummy = false;

    Vector3 PtoD;
    float time = 0f;
    float nowHP = 0;

    public void OnDamage(float AP)
    {
        if (Manager_Tutorial.BasicAttack_end == false)
        {
            Manager_Tutorial.BasicAttack_end = true;
        }
        StartCoroutine(Damage_Anim(AP));
    }

    public void OnDead()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        hp_of_dummy.gameObject.SetActive(false);
        isDead = true;
    }

    IEnumerator Damage_Anim(float AP)
    {
        GetComponent<Animator>().SetTrigger("Damage");
        PtoD = Player.position - transform.position;
        PtoD.Normalize();

        //-HP
        if (Step_KillDummy)
        {
            nowHP = maxHP - AP;
            maxHP = nowHP;
            hp_of_dummy.HP_Bar.fillAmount = nowHP * 0.01f;
            if (maxHP <= 0)
            {
                OnDead();
            }
        }

        while (time < 1.5f)
        {
            time += Time.deltaTime;
            GetComponent<Animator>().SetFloat("x", PtoD.x);
            GetComponent<Animator>().SetFloat("z", PtoD.z);
            yield return null;
        }
        time = 0;
    }
}
