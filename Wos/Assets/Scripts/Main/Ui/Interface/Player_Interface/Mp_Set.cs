using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mp_Set : MonoBehaviour
{
    public Image MpBar;
    public TMP_Text NowMp;

    float MaxMp = 100;
    float CurMp = 100;

    public float Get_CurMp()
    {
        return CurMp;
    }

    public void UseMp(float skillmp)
    {
        CurMp -= skillmp;
        MpBar.fillAmount = CurMp / MaxMp;
        NowMp.text = $"({CurMp} / {MaxMp})";
    }
}
