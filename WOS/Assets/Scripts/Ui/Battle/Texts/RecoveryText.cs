using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecoveryText : MonoBehaviour
{
    [HideInInspector]
    public Transform myTextZone;
    public TMP_Text Text;
    public Image Icon;

    public void ShowRecoveryAp(float Ap, bool isHp)
    {
        Text.text = $"+{Ap}";
        Vector3 pos = Camera.main.WorldToScreenPoint(myTextZone.position);
        transform.position = pos;
        if (isHp)
        {
            Text.color = Color.red;
            Icon.color = Color.red;
        }
        else
        {
            Text.color = Color.blue;
            Icon.color = Color.blue;
        }

        StartCoroutine(ShowingText());
    }

    IEnumerator ShowingText()
    {
        float time = 1.0f;
        while (time > 0)
        {
            transform.position -= Vector3.down * 0.5f;
            time -= Time.deltaTime;
            yield return null;
        }

        Transform Recyclebin = transform.parent.GetComponent<Battle_Window>().RecycleBin_RecoveryText;
        transform.SetParent(Recyclebin);
    }
}
