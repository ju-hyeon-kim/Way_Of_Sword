using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
    public TMP_Text Level;
    public TMP_Text Speed;
    public TMP_Text Ap;
    public TMP_Text Dp;
    public TMP_Text Hp;
    public TMP_Text Mp;

    public void Update_Status(Player_Stat Stat) // 레벨업 했을 경우 or 아이템을 착용,해제 했을 경우
    {
        //Level
        Level.text = Stat.Level.ToString();

        //Speed
        Speed.text = $"{Stat.TotalMspeed}({Stat.PlayerMspeed}<color=#FF6400>+{Stat.AddMspeed}</color>)";

        //Ap
        Ap.text = $"{Stat.TotalAp}({Stat.PlayerAp}<color=#FF0000>+{Stat.AddAp}</color>)";

        //Dp
        Dp.text = $"{Stat.TotalDp}({Stat.PlayerDp}<color=#008CFF>+{Stat.AddDp}</color>)";

        //Hp
        Hp.text = $"{Stat.MaxHp}({Stat.PlayerHp}<color=#00FF00>+{Stat.AddHp}</color>)";

        //Mp
        Mp.text = $"{Stat.MaxMp}({Stat.PlayerMp}<color=#00FFE6>+{Stat.AddMp}</color>)";
    }
}
