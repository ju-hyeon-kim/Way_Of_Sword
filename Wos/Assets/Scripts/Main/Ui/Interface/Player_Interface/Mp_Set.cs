using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mp_Set : MonoBehaviour
{
    public Player_Stat Stat;

    public Image MpBar;
    public TMP_Text NowMp;

    float regen = 0;

    public void UseMp(float skillmp)
    {
        Stat.CurMp -= skillmp;
        Update_Ui();
    }

    public void Update_Ui()
    {
        MpBar.fillAmount = Stat.CurMp / Stat.MaxMp;
        NowMp.text = $"({Stat.CurMp} / {Stat.MaxMp})";
    }

    void Update() // ü�� ���� ( ������ ���� ȸ���� ���� )
    {
        if (Stat.CurMp < Stat.MaxMp) // ���� ü���� �ִ� ü�º��� ���ٸ�
        {
            regen += Time.deltaTime;
            if (regen >= 5.0f) // 5�ʰ� ���� ������
            {
                Stat.CurMp += Stat.Level;
                if (Stat.CurMp > Stat.MaxMp) Stat.CurMp = Stat.MaxMp;
                Update_Ui();
                regen = 0;
            }
        }
    }
}
