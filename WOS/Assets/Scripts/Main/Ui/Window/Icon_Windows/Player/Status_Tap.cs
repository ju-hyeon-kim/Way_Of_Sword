using TMPro;
using UnityEngine;

public class Status_Tap : MonoBehaviour
{
    public TMP_Text Level;
    public TMP_Text Level_onXpBar;
    public TMP_Text Speed;
    public TMP_Text Ap;
    public TMP_Text Dp;
    public TMP_Text Hp;
    public TMP_Text Mp;

    public void Update_Status(Player_Stat Stat) // ������ ���� ��� or �������� ����,���� ���� ���
    {
        //Level
        Level.text = Stat.Level.ToString();
        Level_onXpBar.text = $"Lv.{Stat.Level}";

        //Speed
        Speed.text = $"{Stat.TotalMspeed}({Stat.PlayerMspeed}<color=#FF6400>+{Stat.AddMspeed}</color>)";

        //Ap
        Ap.text = $"{Stat.TotalAp_Attack}({Stat.PlayerAp}<color=#FF0000>+{Stat.AddAp}</color>)";

        //Dp
        Dp.text = $"{Stat.TotalDp}({Stat.PlayerDp}<color=#008CFF>+{Stat.AddDp}</color>)";

        //Hp
        Hp.text = $"{Stat.MaxHp}({Stat.PlayerHp}<color=#00FF00>+{Stat.AddHp}</color>)";

        //Mp
        Mp.text = $"{Stat.MaxMp}({Stat.PlayerMp}<color=#00FFE6>+{Stat.AddMp}</color>)";
    }
}
