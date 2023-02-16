using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Monster_Movement
{
    public GameObject myHpBar;
    HpBar_Monster myHpBar_clone = null;

    public override void UnActive_HpBar()
    {
        if (isHpBar_Created())
        {
            myHpBar_clone.gameObject.SetActive(false);
        }
        StartCoroutine(DelayRoaming(2.0f)); // 2초후 로밍상태로 변경
    }

    bool isHpBar_Created() // HpBar가 생성되어있는 확인하는 bool값
    {
        bool b = (myHpBar_clone != null);
        return b;
    }

    public override void isActive_HpBar(bool b)
    {
        if(b)
        {
            if(isHpBar_Created()) // 이미 HpBar가 생성되어있다면
            {
                myHpBar_clone.gameObject.SetActive(true);
            }
            else
            {
                GameObject hpbar = Instantiate(myHpBar, Dont_Destroy_Data.Inst.Battle_Window.transform) as GameObject;
                myHpBar_clone = hpbar.GetComponent<HpBar_Monster>();
                myHpBar_clone.myHpZone = HpZone;
                myHpBar_clone.StartSetting(this, myStat.maxhp());
            }
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

    public override void ResetHp()
    {
        myHpBar_clone.ResetHp();
    }
}
