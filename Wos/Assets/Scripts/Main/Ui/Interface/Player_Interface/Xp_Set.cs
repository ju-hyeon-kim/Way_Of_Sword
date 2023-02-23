using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Xp_Set : MonoBehaviour
{
    public Player_Stat Stat;

    public Image XpBar;
    public TMP_Text NowLevel;
    public TMP_Text NowHp;

    public void Get_Xp(float xp)
    {
        Stat.CurXp += xp;
        if (Stat.CurXp >= Stat.MaxXp)
        {
            Stat.CurXp -= Stat.MaxXp;
            Stat.Level_Up();
        }
        Update_Ui();
    }

    void Update_Ui()
    {
        XpBar.fillAmount = Stat.CurXp / Stat.MaxXp;
        NowHp.text = $"({Stat.CurXp} / {Stat.MaxXp})";
    }
}
