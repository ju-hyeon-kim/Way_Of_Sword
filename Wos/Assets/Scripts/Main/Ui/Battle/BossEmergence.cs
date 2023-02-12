using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossEmergence : MonoBehaviour
{
    public TMP_Text Label;
    public Image Hunting_Bar;
    public TMP_Text Hunting_Count;
    public Animator BE_Massage;

    int Hcount = 0; // Test후 0으로 수정필요

    public void Plus_Hunting_Count()
    {
        if(Hcount <= 10)
        {
            Hcount++;
            if (Hcount == 10)
            {
                Label.color = Color.red;
                isBossEmergence();
            }
            Hunting_Count.text = $"( {Hcount} / 10 )";
            Hunting_Bar.fillAmount = Hcount * 0.1f;
        }
    }

    public void isBossEmergence()
    {
        BE_Massage.SetTrigger("Show");
        Dont_Destroy_Data.Inst.myPlaceManager.GetComponent<Manager_Forest>().BZ_MagicCicle.SetActive(true);
    }
}