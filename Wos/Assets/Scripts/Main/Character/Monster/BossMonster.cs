using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Character_Movement
{
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
