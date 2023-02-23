public class Beatle : NormalMonster
{

    public override void Check_Quest()
    {
        if (Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Quest_Number == 1)
        {
            Dont_Destroy_Data.Inst.Manager_Quest.NowQuest.Add_Count();
        }
    }

    public override void RandomPos()
    {
        myManager.GetComponent<Manager_Forest>().RandomPos_Monster(this.transform);
    }
}
