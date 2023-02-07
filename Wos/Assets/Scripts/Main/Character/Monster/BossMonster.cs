using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Character_Movement
{
    public Monster_Data myData;
    public Collider myAI;
    public Transform CamView;

    Transform myTarget = null;
    bool FinishAppear = false;

    public enum STATE
    {
        Create, Idle, Appear, Battle, Dead
    }

    public STATE myState = STATE.Create;

    public void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case STATE.Create:
                break;
            case STATE.Idle:
                break;
            case STATE.Appear: // 카메라의 시점변경이 끝나면 ChangeState()가 호출되어 Appear로 State가 변경됨
                myAnim.SetTrigger("Howl");
                break;
            case STATE.Battle:
                Dont_Destroy_Data.Inst.Battle_Window.HpBar_Boss.gameObject.SetActive(true);
                Debug.Log("배틀스테이트" + myTarget);
                AttackTarget(myTarget, AttackRange, myData.Ad);
                break;
            case STATE.Dead:
                break;
        }
    }

    void StateProcess()
    {
        switch (myState)
        {
            case STATE.Create:
                break;
            case STATE.Idle:
                break;
            case STATE.Battle:
                break;
            case STATE.Dead:
                break;
        }
    }

    void Start()
    {
        ChangeState(STATE.Idle);
    }

    private void Update()
    {
        StateProcess();
    }

    public void FindTarget(Transform target)
    {
        if(FinishAppear == false)
        {
            // 보스존 출입문이 닫힘


            myTarget = target;
            target.GetComponent<Player_Movement>().Stop_Movement();
            target.GetComponent<Player_Movement>().Uncontrol_Player();

            Dont_Destroy_Data.Inst.Battle_Window.GetComponent<Battle_Window>().BossEmergence.gameObject.SetActive(false);
            MainCam_Controller mainCam = Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller;
            mainCam.Function = ChangeState;
            mainCam.ChangeViewPos = CamView;
            mainCam.ChangeView(this.transform);

            FinishAppear = true;
        }
    }
}
