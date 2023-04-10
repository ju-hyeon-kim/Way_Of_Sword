using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Loading : MonoBehaviour
{
    // "�ε� ��..." & "�ε� �Ϸ�!"
    public TMP_Text Loading_Text;
    [TextArea]
    public string[] Loading_Texts;

    public GameObject AnyKey_Text; // "�ƹ�Ű�� �����ּ���!"
    public Image Loading_Fill; // �ε� ������
    public AudioListener Listener_ofCamera;

    private void Start()
    {
        //����� ������
        if(Dont_Destroy_Data.Inst == null)
        {
            Listener_ofCamera.enabled = true;
        }
        //Bgm
        Manager_Sound.Inst.BgmSource.OnPlay(1);
        // "�ε� ��..."
        Loading_Text.text = Loading_Texts[0];
        StartCoroutine(Loading());
    }
    
    IEnumerator Loading()
    {
        //�ε� �������� �� ��������
        while (Loading_Fill.fillAmount <= 0.99f)
        {
            //�ε� ������ ����
            float from = Loading_Fill.fillAmount;
            float to = Manager_SceneChange.Inst.ao.progress / 0.9f;
            float fillamount = Mathf.Lerp(from, to, Time.deltaTime);
            Loading_Fill.fillAmount = fillamount;
            yield return null;
        }
        // "�ε� ��..."�� �����̴� ȿ�� ����
        Loading_Text.GetComponent<Animator>().SetTrigger("None");
        // "�ε� �Ϸ�!"
        Loading_Text.text = Loading_Texts[1];
        // "�ƹ�Ű�� �����ּ���!"
        AnyKey_Text.SetActive(true);
    }
}
