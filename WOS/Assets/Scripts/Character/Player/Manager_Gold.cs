using UnityEngine;

public class Manager_Gold : MonoBehaviour
{
    int nowGold = 1000000; //테스트 후 0으로 설정

    public NowGold_Text NowGold_Text;

    public int NowGold
    {
        get => nowGold;
        set
        {
            if(nowGold < value) // 돈을 얻으면
            {
                Dont_Destroy_Data.Inst.ItemAcuisition_Message.Get_Gold(value - nowGold); //메시지 표시;
            }
            nowGold = value;
            NowGold_Text.Change_Gold(nowGold);
        }
    }

    private void Start()
    {
        NowGold_Text.Change_Gold(nowGold);
    }
}