using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player_Dead : MonoBehaviour
{
    public Image myBG;
    public TMP_Text Dead_text;

    public void OnDead()
    {
        StartCoroutine(Drawing_DeadScreen());
    }

    IEnumerator Drawing_DeadScreen()
    {
        float bg_a = 0;
        float dead_a = 0;

        while (Dead_text.color.a <= 1.0f)
        {
            if (myBG.color.a <= 1.0f)
            {
                bg_a += Time.deltaTime * 0.3f;
                myBG.color = new Color(0, 0, 0, bg_a);
            }

            if (myBG.color.a > 0.99f && myBG.color.a < 1.01f) // ±Ù»çÄ¡
            {
                dead_a += Time.deltaTime * 0.3f;
                Dead_text.color = new Color(1, 1, 1, dead_a);
            }

            yield return null;
        }
    }
}
