using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar_Monster : MonoBehaviour
{
    public Monster myMonster;
    public Transform myHpZone;
    public Image HP_Bar;

    float MaxHp = 0;
    float NowHp = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(myHpZone.position);
        transform.position = pos;
    }

    public void StartSetting(Monster monster)
    {
        myMonster = monster;
        MaxHp = monster.myData.MaxHp;
        NowHp = monster.myData.MaxHp;
    }

    public void OnDmage(float dmg)
    {
        NowHp -= dmg;
        HP_Bar.fillAmount = NowHp / MaxHp;
        if (NowHp <= 0)
        {
            myMonster.OnDead();
        }
    }
}
