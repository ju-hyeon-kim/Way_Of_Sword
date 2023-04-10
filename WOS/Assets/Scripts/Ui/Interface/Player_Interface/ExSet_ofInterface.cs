using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ExSet_ofInterface : MonoBehaviour
{
    public ExpendablesSlot_ofInterface[] ExSlots;
    public Player Player;

    public void Use_ExItem(int num)
    {
        Expendables_Data ExData = ExSlots[num].myItem.myData as Expendables_Data;
        if (ExData.AbillityExplanation == "ü��ȸ��")
        {
            RecoveryHp(num);
        }
        else
        {
            RecoveryMp(num);
        }
    }

    void RecoveryHp(int num)
    {
        Expendables_Data ExData = ExSlots[num].myItem.myData as Expendables_Data;
        Player_Stat stat = Player.GetComponent<Player_Stat>();
        if(stat.CurHp < stat.MaxHp)
        {
            Play_DrinkSound();

            stat.CurHp += ExData.Ap;
            if (stat.CurHp > stat.MaxHp)
            {
                stat.CurHp = stat.MaxHp;
            }
            Player.RecoveryText_Zone.OnRecoveryText(ExData.Ap, true, Dont_Destroy_Data.Inst.BattleWindow_ofPlayer);
            Player.RecoverytEffects[0].Play();
            Player.RecoverytEffects[0].GetComponent<AudioSource>().Play();
            ExSlots[num].Quantity--;
        }
    }

    void RecoveryMp(int num)
    {
        Expendables_Data ExData = ExSlots[num].myItem.myData as Expendables_Data;
        Player_Stat stat = Player.GetComponent<Player_Stat>();
        if (stat.CurMp < stat.MaxMp)
        {
            stat.CurMp += ExData.Ap;
            Play_DrinkSound();

            if (stat.CurMp > stat.MaxMp)
            {
                stat.CurMp = stat.MaxMp;
            }
            Player.RecoveryText_Zone.OnRecoveryText(ExData.Ap, false, Dont_Destroy_Data.Inst.BattleWindow_ofPlayer);
            Player.RecoverytEffects[1].Play();
            Player.RecoverytEffects[1].GetComponent<AudioSource>().Play();
            ExSlots[num].Quantity--;
        }
    }

    void Play_DrinkSound()
    {
        Player.DrinkSound();
    }
}
