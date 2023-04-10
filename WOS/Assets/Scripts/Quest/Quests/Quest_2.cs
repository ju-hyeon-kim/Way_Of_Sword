public class Quest_2 : Quest_Data
{
    Manager_Quest MQ;
    int Nowkill_Count = 0;
    int Maxkill_Count = 1;

    public override void Start_Questing()
    {
        MQ = Dont_Destroy_Data.Inst.Manager_Quest;
    }

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
        if (Nowkill_Count < Maxkill_Count)
        {
            ++Nowkill_Count;
            MQ.Add_KillCount(Nowkill_Count);
            if (Nowkill_Count == Maxkill_Count)
            {
                MQ.Complete_Quest();
            }
        }
    }
}
