using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Loading : MonoBehaviour
{
    public TMP_Text Loading_Text;
    public GameObject AnyKey_Text;

    [TextArea]
    public string[] Loading_Texts;

    private void Start()
    {
        Loading_Text.text = Loading_Texts[0];
    }

    private void Update()
    {
        if(Manager_SceneChange.inst.ao.progress >= 0.9f)
        {
            Loading_Text.GetComponent<Animator>().SetTrigger("None");
            Loading_Text.text = Loading_Texts[1];
            AnyKey_Text.SetActive(true);
        }
    }
}
