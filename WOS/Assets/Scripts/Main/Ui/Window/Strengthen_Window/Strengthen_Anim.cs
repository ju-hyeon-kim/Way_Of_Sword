using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strengthen_Anim : MonoBehaviour
{
    public GameObject Strengthen_Objects;
    public GameObject FireAnim;
    public GameObject SparkEffect;
    public GameObject Congrats_Effect;
    public Strengthen_Slot Strengthen_Slot;

    int count = 0;

    public void OnAnim()
    {
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
            string s = "강화가 성공했습니다!";
            Nwindow.WindowSetting(s, Success_Strengthen);
            Nwindow.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    void Success_Strengthen()
    {
        Dont_Destroy_Data.Inst.Inventory_Window.Put_Item(Strengthen_Slot.myItem);
    }
}
