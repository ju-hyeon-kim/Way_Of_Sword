using System.Collections;
using UnityEngine;

public class NormalMonster : Monster_Movement
{
    [Header("-----NormalMonset-----")]
    public Transform HpZone;
    public GameObject myHpBar;

    HpBar_NormalMonster myHpBar_clone = null;
    

    public override void Ready_Roaming()
    {
        if (isHpBar_Created())
        {
            myHpBar_clone.gameObject.SetActive(false);
        }
        StartCoroutine(DelayRoaming(2.0f)); // 2���� �ιֻ��·� ����
    }

    bool isHpBar_Created() // HpBar�� �����Ǿ��ִ� Ȯ���ϴ� bool��
    {
        bool b = (myHpBar_clone != null);
        return b;
    }

    public override void Active_HpBar(bool b)
    {
        if (b)
        {
            if (isHpBar_Created()) // �̹� HpBar�� �����Ǿ��ִٸ�
            {
                myHpBar_clone.gameObject.SetActive(true);
            }
            else
            {
                BattleWindow_ofMonster BW = myManager.BattleWindow_ofMonster as BattleWindow_ofMonster;
                GameObject hpbar = Instantiate(myHpBar, BW.transform) as GameObject;
                BW.HpBar_List.Add(hpbar); // ������ �̵��Ҷ� �ѹ��� ����
                myHpBar_clone = hpbar.GetComponent<HpBar_NormalMonster>();
                myHpBar_clone.myHpZone = HpZone;
                myHpBar_clone.StartSetting(this, myStat.maxhp());
            }
        }
        else
        {
            myHpBar_clone.gameObject.SetActive(false);
        }
    }

    public override void Ondamge_HpBar(float dmg)
    {
        myHpBar_clone.GetComponent<HpBar_NormalMonster>().OnDmage(dmg);
    }

    public override void FindTarget(Transform target)
    {
        myTarget = target;
        StopAllCoroutines();
        ChangeState(MonstertState.Battle);
    }

    IEnumerator DelayRoaming(float t)
    {
        yield return new WaitForSeconds(t);
        ChangeState(MonstertState.Roaming);
    }

    public override void ResetHp()
    {
        myHpBar_clone.ResetHp();
    }

    public override void CorpseDown()
    {
        if (DeadTime > 0)
        {
            DeadTime -= Time.deltaTime;
            transform.Translate(Vector3.down * (Time.deltaTime * DownSpeed));
        }
        else
        {
            DeadTime = 15.0f;
            ChangeState(MonstertState.Resurrection);
        }
    }
}
