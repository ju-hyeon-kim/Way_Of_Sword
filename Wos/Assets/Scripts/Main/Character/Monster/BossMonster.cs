using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonster : Monster_Movement
{
    public Transform CamView;
    bool FinishAppear = false;

    public override void FindTarget(Transform target)
    {
        if(FinishAppear == false)
        {
            // ∫∏Ω∫¡∏ √‚¿‘πÆ¿Ã ¥›»˚

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

    public override void Conect_HpBar()
    {
        Dont_Destroy_Data.Inst.Battle_Window.HpBar_Boss.gameObject.SetActive(true);
    }
}
