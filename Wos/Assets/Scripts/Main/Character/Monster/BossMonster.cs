using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster_Movement
{
    public Transform CamView;

    bool FinishAppear = false;
    HpBar_Boss myHpBar;

    public override void FindTarget(Transform target)
    {
        if(FinishAppear == false)
        {
            // ������ ���Թ��� ����
            myManager.BossZone_Door.SetBool("Open", false);

            myTarget = target;
            target.GetComponent<Player_Movement>().Stop_Movement();
            target.GetComponent<Player_Movement>().Uncontrol_Player();

            myManager.BossEmergence.gameObject.SetActive(false);
            MainCam_Controller mainCam = Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller;
            mainCam.Function = ChangeState;
            mainCam.ChangeViewPos = CamView;
            mainCam.ChangeView(this.transform);

            FinishAppear = true;
        }
    }

    public override void Active_HpBar(bool b)
    {
        BattleWindow_ofMonster BW = myManager.GetComponent<Manager_Dungeon>().BattleWindow_ofMonster as BattleWindow_ofMonster;
        myHpBar = BW.HpBar_Boss;
        myHpBar.StartSetting(this, myStat.maxhp());
        myHpBar.gameObject.SetActive(b);
    }

    public override void Ondamge_HpBar(float dmg)
    {
        myHpBar.OnDmage(dmg);
    }

    public void AppearEvent()
    {
        ChangeState(MonstertState.Appear);
        myManager.Boss_AppearEvent.SetTrigger("Boss_Introduce");
    }
}
