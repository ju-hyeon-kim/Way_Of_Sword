using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hp_Set : MonoBehaviour
{
    public Image HpBar;
    public TMP_Text NowHp;

    float MaxHp = 100.0f;
    float CurHp = 100.0f;

    public void OnDamage(float dmg)
    {
        CurHp -= dmg;
        if(CurHp <= 0)
        {
            OnDead();
            CurHp = 0;
        }
        HpBar.fillAmount = CurHp / MaxHp;
        NowHp.text = $"({CurHp} / {MaxHp})";
    }

    public void OnDead()
    {
        Dont_Destroy_Data.Inst.Player.GetComponent<Player>().Change_Mode(Mode.DEAD);
    }
}
