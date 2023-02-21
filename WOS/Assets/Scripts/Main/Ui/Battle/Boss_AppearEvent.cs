using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_AppearEvent : MonoBehaviour
{
    public void End_BossIntroduce() // AnimEvent
    {
        //리턴 뷰
        MainCam_Controller Cam = Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller;
        Cam.ReturnView(false);
        // Battle_Start 애니메이션
        GetComponent<Animator>().SetTrigger("Battle_Start");
    }
}
