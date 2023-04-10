using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hp_Set : MonoBehaviour
{
    public Player_Stat Stat;

    public Image HpBar;
    public TMP_Text NowHp;

    float regen = 0;

    public void OnDamage(float dmg)
    {
        Stat.CurHp -= dmg;

        if (Stat.CurHp <= 0)
        {
            OnDead();
            Stat.CurHp = 0;
        }
        Update_Ui();
    }

    public void OnDead()
    {
        Dont_Destroy_Data.Inst.Player.GetComponent<Player>().Change_Mode(Mode.DEAD);
    }

    public void Update_Ui()
    {
        HpBar.fillAmount = Stat.CurHp / Stat.MaxHp;
        NowHp.text = $"({Stat.CurHp} / {Stat.MaxHp})";
    }

    void Update() // 체력 리젠 ( 레벨에 따라 회복량 증가 )
    {
        if (Stat.CurHp < Stat.MaxHp) // 현재 체력이 최대 체력보다 적다면
        {
            regen += Time.deltaTime;
            if (regen >= 5.0f) // 5초가 지날 때마다
            {
                Stat.CurHp += Stat.Level;
                if (Stat.CurHp > Stat.MaxHp) Stat.CurHp = Stat.MaxHp;
                Update_Ui();
                regen = 0;
            }
        }
    }
}
