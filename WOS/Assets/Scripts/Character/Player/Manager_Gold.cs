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
            if(nowGold < value) // ���� ������
            {
                Dont_Destroy_Data.Inst.ItemAcuisition_Message.Get_Gold(value - nowGold); //�޽��� ǥ��;
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