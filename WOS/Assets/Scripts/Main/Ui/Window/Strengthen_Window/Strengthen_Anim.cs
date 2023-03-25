using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Strengthen_Anim : MonoBehaviour
{
    public GameObject Strengthen_Objects;
    public GameObject FireAnim;
    public GameObject SparkEffect;
    public GameObject Congrats_Effect;
    public Strengthen_Slot Strengthen_Slot;

    int count = 0;
    bool StrengthenResult;

    public void OnAnim(bool result)
    {
        StrengthenResult = result;
        Strengthen_Objects.SetActive(false);
        FireAnim.SetActive(true);
    }

    public void OnSparkEffect() //AnimEevent
    {
        SparkEffect.SetActive(true);
    }

    public void Count() //AnimEevent
    {
        ++count;
        if(count == 3)
        {
            count = 0;
            FireAnim.SetActive(false);
            Notice_Window Nwindow = Dont_Destroy_Data.Inst.Notice_Window;

            string contant = "강화에 실패했습니다ㅠㅠ";
            if(StrengthenResult)
            {
                contant = "강화가 성공했습니다!";
            }
            
            Nwindow.WindowSetting(contant, End_Strengthen, Convert.ToInt32(StrengthenResult));
            Nwindow.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    void End_Strengthen()
    {
        Dont_Destroy_Data.Inst.Inventory_Window.PutItem(Strengthen_Slot.myItem);
    }
}
