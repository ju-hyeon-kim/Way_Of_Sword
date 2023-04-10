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
    public GameObject BrokenItem;
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
        //Sfx
        GetComponent<AudioSource>().Play();
    }

    public void Count() //AnimEevent
    {
        ++count;
        if(count == 3)
        {
            count = 0;
            FireAnim.SetActive(false);
            Notice_Window Nwindow = Dont_Destroy_Data.Inst.Notice_Window;

            string contant;
            if (StrengthenResult)
            {
                contant = "강화가 성공했습니다!";
            }
            else
            {
                contant = "강화에 실패했습니다ㅠㅠ\n(아이템은 파괴됩니다.)";
                BrokenItem.SetActive(true);
            }
            
            Nwindow.WindowSetting(contant, End_Strengthen, Convert.ToInt32(StrengthenResult));
            Nwindow.gameObject.SetActive(true);
            Nwindow.PlaySound(Convert.ToInt32(StrengthenResult));
            this.gameObject.SetActive(false);
        }
    }

    void End_Strengthen()
    {
        if(StrengthenResult)
        {
            Dont_Destroy_Data.Inst.Inventory_Window.PutItem(Strengthen_Slot.myItem);
        }
        else
        {
            Destroy(Strengthen_Slot.myItem.gameObject);
            BrokenItem.SetActive(false);
        }
    }
}
