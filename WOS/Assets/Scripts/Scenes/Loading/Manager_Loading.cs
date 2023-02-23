using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Loading : MonoBehaviour
{
    public TMP_Text Loading_Text;
    public Image Loading_Fill;
    public GameObject AnyKey_Text;

    [TextArea]
    public string[] Loading_Texts;

    private void Start()
    {
        Loading_Text.text = Loading_Texts[0];
    }

    private void Update()
    {
        if (Manager_SceneChange.Inst.ao.progress >= 0.9f)
        {
            Loading_Fill.fillAmount = Manager_SceneChange.Inst.ao.progress / 0.9f;
            Loading_Text.GetComponent<Animator>().SetTrigger("None");
            Loading_Text.text = Loading_Texts[1];
            AnyKey_Text.SetActive(true);
        }
    }
}
