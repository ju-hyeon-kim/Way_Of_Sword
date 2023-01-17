using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Quest_1 : Quest_Data
{
    public Manager_Quest Manager_Quest;
    int Nowkill_Count = 0;
    int Maxkill_Count = 5;

    public override bool isCounting()
    {
        return true;
    }

    public override int Now_Count()
    {
        return Nowkill_Count;
    }

    public override int Max_Count()
    {
        return Maxkill_Count;
    }

    public override void Add_Count()
    {
        if(Nowkill_Count < Maxkill_Count)
        {
            ++Nowkill_Count;
            if(Nowkill_Count == Maxkill_Count)
            {
                Manager_Quest.Complete_Quest();
            }
        }
    }
}
