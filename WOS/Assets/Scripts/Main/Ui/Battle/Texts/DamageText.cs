using System.Collections;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public Transform myDamageZone;
    public Color OrangeColor;

    public void ShowDamage(float dmg, bool isPlayer)
    {
        if (isPlayer)
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(myDamageZone.position);
            transform.position = pos;

            GetComponent<TMP_Text>().color = Color.red;
            GetComponent<TMP_Text>().fontSize = 30.0f;
        }
        else
        {
            GetComponent<TMP_Text>().color = OrangeColor;
            GetComponent<TMP_Text>().fontSize = 40.0f;
        }

        StartCoroutine(ShowingDamage(dmg, isPlayer));
    }

    IEnumerator ShowingDamage(float dmg, bool isPlayer)
    {
        GetComponent<TMP_Text>().text = dmg.ToString();

        float time = 1.0f;
        while (time > 0)
        {
            if (isPlayer)
            {
                transform.position -= Vector3.down * 0.5f;
            }
            else
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(myDamageZone.position);
                transform.position = pos;
            }
            time -= Time.deltaTime;
            yield return null;
        }

        Transform Recyclebin = transform.parent.GetComponent<Battle_Window>().RecycleBin_Dmg;
        transform.SetParent(Recyclebin);
    }
    //생성되고 떨어지면서 흐릿해지는 효과는 나중에 구현
}
