using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Monster_Movement
{
    public GameObject myHpBar;
    HpBar_Monster myHpBar_clone = null;

    public override void Check_HpBar()
    {
        if (myHpBar_clone != null)
        {
            myHpBar_clone.gameObject.SetActive(false);
        }
    }

    public override void Conect_HpBar()
    {
        GameObject hpbar = Instantiate(myHpBar, Dont_Destroy_Data.Inst.Battle_Window.transform) as GameObject;
        myHpBar_clone = hpbar.GetComponent<HpBar_Monster>();
        myHpBar_clone.myHpZone = HpZone;
        myHpBar_clone.StartSetting(this);
    }

    public override void Ondamge_HpBar(float dmg)
    {
        myHpBar_clone.GetComponent<HpBar_Monster>().OnDmage(dmg);
    }

    public override void Unactive_HpBar()
    {
        myHpBar_clone.gameObject.SetActive(false);
    }
}
