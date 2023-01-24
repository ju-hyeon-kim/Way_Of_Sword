using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door_Zone : MonoBehaviour
{
    public GameObject FadeOut;

    private void OnTriggerEnter(Collider obj)
    {
        FadeOut.SetActive(true);
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        while(FadeOut.GetComponent<Image>().fillAmount < 1)
        {
            FadeOut.GetComponent<Image>().fillAmount += Time.deltaTime;
            yield return null;
        }
        Manager_SceneChange.Inst.ChangeScene("Story2");
    }
}
