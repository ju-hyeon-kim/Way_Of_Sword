using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public Transform myDamageZone;

    public void ShowDamage(float dmg)
    {
        StartCoroutine(ShowingDamage(dmg));
    }

    IEnumerator ShowingDamage(float dmg)
    {
        GetComponent<TMP_Text>().text = dmg.ToString();

        float time = 1.0f;
        while (time > 0)
        {
            time -= Time.deltaTime;
            Vector3 pos = Camera.main.WorldToScreenPoint(myDamageZone.position);
            transform.position = pos;
            yield return null;
        }

        Transform Recyclebin = transform.parent.GetComponent<Battle_Window>().RecycleBin_Dmg;
        transform.SetParent(Recyclebin);
    }
    //�����ǰ� �������鼭 �帴������ ȿ���� ���߿� ����
}
