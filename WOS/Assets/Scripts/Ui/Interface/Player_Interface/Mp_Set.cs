using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mp_Set : MonoBehaviour
{
    public Player_Stat Stat;

    public Image MpBar;
    public TMP_Text NowMp;

    float regen = 0;

    public void UseMp(float skillmp)
    {
        Stat.CurMp -= skillmp;
        Update_Ui();
    }

    public void Update_Ui()
    {
        MpBar.fillAmount = Stat.CurMp / Stat.MaxMp;
        NowMp.text = $"({Stat.CurMp} / {Stat.MaxMp})";
    }

    void Update() // 체력 리젠 ( 레벨에 따라 회복량 증가 )
    {
        if (Stat.CurMp < Stat.MaxMp) // 현재 체력이 최대 체력보다 적다면
        {
            regen += Time.deltaTime;
            if (regen >= 5.0f) // 5초가 지날 때마다
            {
                Stat.CurMp += Stat.Level;
                if (Stat.CurMp > Stat.MaxMp) Stat.CurMp = Stat.MaxMp;
                Update_Ui();
                regen = 0;
            }
        }
    }
}
