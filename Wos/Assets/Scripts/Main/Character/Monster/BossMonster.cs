using UnityEngine;
using UnityEngine.Events;

public enum BossPhase
{
    Phase1, Phase2, Phase3
}

public class BossMonster : Monster_Movement
{
    [Header("-----BossMonster-----")]
    public Transform CamView;
    public GameObject[] Auras;
    public BossSkill_Range[] Skill_Ranges;
    public GameObject[] Skill_Effects;
    public Transform[] SkillEffect_Pos;
    public Transform SkillEffect_Bin; //오브젝트 풀링


    //페이즈에 따라 달라지는 스킬, AttackCount
    BossPhase nowPhase = BossPhase.Phase1;
    int AttackCount = 0;
    int SkillNum = 0;

    bool FinishAppear = false;
    HpBar_Boss myHpBar;

    public void ChangePhase(BossPhase p)
    {
        if (nowPhase == p) return;
        nowPhase = p;
        switch (nowPhase)
        {
            case BossPhase.Phase2: // 2번 공격 후 썬더볼트 발동
                Auras[0].SetActive(true);
                SkillNum = 0;
                break;
            case BossPhase.Phase3: // 2번 공격 후 그린토네이도 발동
                Auras[0].SetActive(false);
                Auras[1].SetActive(true);
                SkillNum = 1;
                break;
        }
    }

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

    public override void BossAction()
    {
        if(nowPhase > 0)
        {
            AttackCount++;
            if (AttackCount == 3)  // 3번째 공격후 스킬사용
            {
                StopCoroutine(CoAttack);
                SkillReady(SkillNum);
                AttackCount = 0;
            }
        }
    }

    public virtual void SkillReady(int skillnum) { }
    public virtual void SkillAction(int skillnum) { } //스킬레인지의 AnimEvent가 호출하여 실행
    public virtual void SkillEnd(int skillnum) { }
}
