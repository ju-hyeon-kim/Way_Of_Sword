using UnityEngine;
using UnityEngine.UI;

public class HpBar_NormalMonster : MonoBehaviour
{
    public NormalMonster myMonster;
    public Transform myHpZone;
    public Image HP_Bar;

    float NowHp = 0;
    float MaxHp = 0;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(myHpZone.position);
        transform.position = pos;
    }

    public void StartSetting(NormalMonster monster, float maxhp)
    {
        myMonster = monster;
        MaxHp = maxhp;
        NowHp = MaxHp;
    }

    public void OnDmage(float dmg)
    {
        NowHp -= dmg;
        HP_Bar.fillAmount = NowHp / MaxHp;
        if (NowHp <= 0)
        {
            myMonster.ChangeState(MonstertState.Dead);
        }
    }

    public void ResetHp()
    {
        NowHp = MaxHp;
        HP_Bar.fillAmount = 1.0f;
    }
}
