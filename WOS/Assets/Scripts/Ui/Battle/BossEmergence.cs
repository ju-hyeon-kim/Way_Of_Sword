using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossEmergence : MonoBehaviour
{
    public GameObject BossZone_MagicCircle;
    public TMP_Text Label;
    public Image Hunting_Bar;
    public TMP_Text Hunting_Count;
    public Animator BE_Massage;

    int Hcount = 0;
    int Maxcount = 10; // Test후 10으로 수정필요

    public void Plus_Hunting_Count()
    {
        if (Hcount < Maxcount)
        {
            Hcount++;
            if (Hcount == Maxcount)
            {
                Label.color = Color.red;

                //보스존 입장가능
                BE_Massage.SetTrigger("Show");
                BossZone_MagicCircle.SetActive(true);
            }
            Hunting_Count.text = $"( {Hcount} / {Maxcount} )";
            Hunting_Bar.fillAmount = (float)Hcount / (float)Maxcount;
        }
    }
}