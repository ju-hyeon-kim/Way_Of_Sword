using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar_Boss : MonoBehaviour
{
    public Image[] Bars;
    public TMP_Text BarCount;
    public TMP_Text Hp_text;

    BossMonster myMonster;
    float NowHp = 0;
    float MaxHp = 0;
    int BarNumber = 0;
    int NowBarCount = 0;

    public void StartSetting(BossMonster monster, float maxhp)
    {
        myMonster = monster;
        NowHp = maxhp;
        MaxHp = maxhp;
        Hp_text.text = $"( {NowHp} / {MaxHp} )";
        NowBarCount = Bars.Length;
        BarCount.text = $"x{NowBarCount}";
    }

    public void OnDmage(float dmg)
    {
        NowHp -= dmg;

        Bars[BarNumber].fillAmount = (NowHp/Bars.Length) / (MaxHp/Bars.Length);
        Hp_text.text = $"( {NowHp} / {MaxHp} )";

        if(NowHp < (MaxHp / Bars.Length) * (Bars.Length - (BarNumber + 1)))
        {
            BarNumber++;
            BarCount.text = $"x{--NowBarCount}";
        }

        if (NowHp <= 0)
        {
            myMonster.OnDead();
        }
    }
}
