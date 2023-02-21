using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Monster_Movement
{
    [Header("-----NormalMonset-----")]
    public GameObject myHpBar;
    HpBar_Monster myHpBar_clone = null;

    public override void Ready_Roaming()
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

    public override void Active_HpBar(bool b)
    {
        if(b)
        {
            if(isHpBar_Created()) // 이미 HpBar가 생성되어있다면
            {
                myHpBar_clone.gameObject.SetActive(true);
            }
            else
            {
                BattleWindow_ofMonster BW = myManager.BattleWindow_ofMonster as BattleWindow_ofMonster;
                GameObject hpbar = Instantiate(myHpBar, BW.transform) as GameObject;
                BW.HpBar_List.Add(hpbar); // 마을로 이동할때 한번에 삭제
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
        ChangeState(MonstertState.Battle);
    }

    IEnumerator DelayRoaming(float t)
    {
        yield return new WaitForSeconds(t);
        ChangeState(MonstertState.Roaming);
    }

    public override void ResetHp()
    {
        myHpBar_clone.ResetHp();
    }
}
