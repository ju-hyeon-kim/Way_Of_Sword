using UnityEngine;

public enum BossPhase
{
    Phase1, Phase2, Phase3
}

public class BossMonster : Monster_Movement
{
    public Transform CamView;

    BossPhase nowPhase = BossPhase.Phase1;

    bool FinishAppear = false;
    HpBar_Boss myHpBar;

    public override void FindTarget(Transform target)
    {
        if (FinishAppear == false)
        {
            //보스전 테스트용 코드
            myTarget = target;
            ChangeState(MonstertState.Battle);

            //보스등장 컷씬 -> 테스트 후 주석풀기
            /*myManager.BossZone_Door.SetBool("Open", false);
            target.GetComponent<Player_Movement>().Stop_Movement();
            target.GetComponent<Player_Movement>().Uncontrol_Player();
            myManager.BossEmergence.gameObject.SetActive(false);
            MainCam_Controller mainCam = Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller;
            mainCam.Function = ChangeState;
            mainCam.ChangeViewPos = CamView;
            mainCam.ChangeView(this.transform);*/

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
