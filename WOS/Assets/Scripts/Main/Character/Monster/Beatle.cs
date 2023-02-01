using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatle : Monster
{
    public override void Check_Quest()
    {
        if(Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Quest_Number == 1)
        {
            Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Add_Count();
        }
    }
}
