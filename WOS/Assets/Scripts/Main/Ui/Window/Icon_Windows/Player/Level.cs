using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public TMP_Text Now_Level;
    public TMP_Text Xp_Reading;

    public Image Xp_Bar;
    public TMP_Text Nowlevel_ofXpBar;
    public TMP_Text Xp_Reading_ofXpBar;

    int nowXp = 0;
    int maxXp = 100;

    public void Get_Xp(int Xp)
    {
        nowXp += Xp;
        Xp_Reading.text = $"( {nowXp}/{maxXp} )";

        //Main_Interface�� Xp_Bar/NowLevel�� ����
        Xp_Bar.fillAmount = (nowXp % maxXp) * 0.01f;
        Nowlevel_ofXpBar.text = Now_Level.text; // ������ �Ҷ��� ����
        Xp_Reading_ofXpBar.text = $"( {nowXp}/{maxXp} )";
    }
}
