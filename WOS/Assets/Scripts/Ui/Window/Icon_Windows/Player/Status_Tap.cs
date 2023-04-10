using TMPro;
using UnityEngine;

public class Status_Tap : MonoBehaviour
{
    public Player_Stat Player_Stat;
    public TMP_Text Level;
    public TMP_Text Level_onXpBar;
    public TMP_Text Speed;
    public TMP_Text Ap;
    public TMP_Text Dp;
    public TMP_Text Hp;
    public TMP_Text Mp;

    public void Update_Status() // 레벨업 했을 경우 or 아이템을 착용,해제 했을 경우
    {
        //Level
        Level.text = Player_Stat.Level.ToString();
        Level_onXpBar.text = $"Lv.{Player_Stat.Level}";

        //Speed
        Speed.text = $"{Player_Stat.TotalMspeed}({Player_Stat.PlayerMspeed}<color=#FF6400>+{Player_Stat.AddMspeed}</color>)";

        //Ap
        Ap.text = $"{Player_Stat.TotalAp_Attack}({Player_Stat.PlayerAp}<color=#FF0000>+{Player_Stat.AddAp}</color>)";

        //Dp
        Dp.text = $"{Player_Stat.TotalDp}({Player_Stat.PlayerDp}<color=#008CFF>+{Player_Stat.AddDp}</color>)";

        //Hp
        Hp.text = $"{Player_Stat.MaxHp}({Player_Stat.PlayerHp}<color=#00FF00>+{Player_Stat.AddHp}</color>)";

        //Mp
        Mp.text = $"{Player_Stat.MaxMp}({Player_Stat.PlayerMp}<color=#00FFE6>+{Player_Stat.AddMp}</color>)";
    }
}
