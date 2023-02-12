using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Xp_Set : MonoBehaviour
{
    public Image XpBar;
    public TMP_Text NowLevel;
    public TMP_Text NowHp;
    public ParticleSystem LevelUp_Eff;
    public GameObject LevelUp_Event;

    float Level = 1;
    float MaxXp = 20; // 100으로 고정
    float CurXp = 0;

    public void Get_Xp(float xp)
    {
        CurXp += xp;
        if(CurXp >= MaxXp)
        {
            CurXp -= MaxXp;
            LevelUp();
        }
        Update_XpUi();
    }

    void LevelUp()
    {
        MaxXp += 20.0f;
        Level++;
        NowLevel.text = $"Lv.{Level}";

        LevelUp_Eff.Play();
        LevelUp_Event.SetActive(true);
    }

    void Update_XpUi()
    {
        XpBar.fillAmount = CurXp / MaxXp;
        NowHp.text = $"({CurXp} / {MaxXp})";
    }
}
