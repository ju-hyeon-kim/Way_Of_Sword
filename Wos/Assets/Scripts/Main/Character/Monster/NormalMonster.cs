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
        StartCoroutine(DelayRoaming(2.0f)); // 2초후 로밍상태로 변경
    }

    public override void isActive_HpBar(bool b)
    {
        if(b)
        {
            GameObject hpbar = Instantiate(myHpBar, Dont_Destroy_Data.Inst.Battle_Window.transform) as GameObject;
            myHpBar_clone = hpbar.GetComponent<HpBar_Monster>();
            myHpBar_clone.myHpZone = HpZone;
            myHpBar_clone.StartSetting(this, myStat.MaxHp());
        }
        else
        {
            myHpBar_clone.gameObject.SetActive(false);
        }
        
    }

    public override void Ondamge_HpBar(float dmg)
    {
        myHpBar_clone.GetComponent<HpBar_Monster>().OnDmage(dmg);
    }

    public override void FindTarget(Transform target)
    {
        myTarget = target;
        StopAllCoroutines();
        ChangeState(STATE.Battle);
    }

    IEnumerator DelayRoaming(float t)
    {
        yield return new WaitForSeconds(t);
        ChangeState(STATE.Roaming);
    }
}
