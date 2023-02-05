using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Character_Movement
{
    public Collider myAI;
    public Transform CamView;
    Transform myTarget = null;

    public enum STATE
    {
        Create, Idle, Appear, Battle, Dead
    }

    public STATE myState = STATE.Create;

    void ChangeState(STATE s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case STATE.Create:
                break;
            case STATE.Idle:
                break;
            case STATE.Appear:
                //myAnim.SetTrigger("Howl");
                break;
            case STATE.Battle:
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
        myTarget = target;
        target.GetComponent<Player_Movement>().Stop_Movement();
        target.GetComponent<Player_Movement>().Uncontrol_Player();

        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.ChangeViewPos = CamView;
        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.ChangeView(this.transform);
        //ChangeState(STATE.Appear);
    }
}
