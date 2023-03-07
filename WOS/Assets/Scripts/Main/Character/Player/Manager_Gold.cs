using UnityEngine;

public class Manager_Gold : MonoBehaviour
{
    int nowGold = 1000000; //�׽�Ʈ �� 0���� ����

    public NowGold_Text NowGold_Text;

    public int NowGold
    {
        get => nowGold;
        set
        {
            nowGold = value;
            NowGold_Text.Change_Gold(nowGold);
        }
    }

    private void Start()
    {
        NowGold_Text.Change_Gold(nowGold);
    }

    public void PlusGold(int price)
    {
        nowGold += price;
        NowGold_Text.Change_Gold(nowGold);
    }

    public void MinusGold(int price)
    {
        nowGold -= price;
        NowGold_Text.Change_Gold(nowGold);
    }
}