using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HpBar_Boss : MonoBehaviour
{
    public Image[] Bars;
    public TMP_Text BarCount;
    public TMP_Text Hp_text;

    BossMonster myMonster;
    float NowHp = 0;
    float MaxHp = 0;
    int BarNumber = 0;
    int NowBarCount = 0;

    Coroutine coHpCalculating = null;

    public void StartSetting(BossMonster monster, float maxhp)
    {

        myMonster = monster;
        NowHp = maxhp;
        MaxHp = maxhp;
        Hp_text.text = $"( {NowHp} / {MaxHp} )";
        NowBarCount = Bars.Length;
        BarCount.text = $"x{NowBarCount}";
    }

    public void OnDmage(float dmg)
    {
        NowHp -= dmg;

        if(NowHp <= 0) // Á×À½
        {
            myMonster.ChangeState(MonstertState.Dead);
            NowHp = 0;
        }
        else // Á×Áö ¾Ê¾ÒÀ» °æ¿ì
        {
            if (NowHp < (MaxHp / Bars.Length) * (Bars.Length - (BarNumber + 1)))
            {

                Bars[BarNumber].fillAmount = 0;

                if (BarNumber < Bars.Length - 1)
                {
                    BarNumber++;
                }



                if (BarNumber == 1)
                {
                    myMonster.ChangePhase(BossPhase.Phase2);
                }
                else if (BarNumber == 2)
                {
                    myMonster.ChangePhase(BossPhase.Phase3);
                }
                BarCount.text = $"x{--NowBarCount}";
            }

            float chagefill = NowHp % (MaxHp / Bars.Length) / (MaxHp / Bars.Length);

            if (coHpCalculating != null)
            {
                StopCoroutine(coHpCalculating);
            }
            coHpCalculating = StartCoroutine(HpCalculating(chagefill));

            Hp_text.text = $"( {NowHp} / {MaxHp} )";
        }
    }

    IEnumerator HpCalculating(float ChangeFill)
    {
        while (Bars[BarNumber].fillAmount > ChangeFill + 0.0001f)
        {
            if (Bars[Bars.Length - 1].fillAmount != 0)
            {
                Bars[BarNumber].fillAmount = Mathf.Lerp(Bars[BarNumber].fillAmount, ChangeFill, Time.deltaTime);
            }
            else
            {
                myMonster.ChangeState(MonstertState.Dead);
                StopCoroutine(coHpCalculating);
            }
            yield return null;
        }
    }
}