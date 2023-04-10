using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Loading : MonoBehaviour
{
    // "로딩 중..." & "로딩 완료!"
    public TMP_Text Loading_Text;
    [TextArea]
    public string[] Loading_Texts;

    public GameObject AnyKey_Text; // "아무키나 눌러주세요!"
    public Image Loading_Fill; // 로딩 게이지
    public AudioListener Listener_ofCamera;

    private void Start()
    {
        //오디오 리스너
        if(Dont_Destroy_Data.Inst == null)
        {
            Listener_ofCamera.enabled = true;
        }
        //Bgm
        Manager_Sound.Inst.BgmSource.OnPlay(1);
        // "로딩 중..."
        Loading_Text.text = Loading_Texts[0];
        StartCoroutine(Loading());
    }
    
    IEnumerator Loading()
    {
        //로딩 게이지가 꽉 찰때까지
        while (Loading_Fill.fillAmount <= 0.99f)
        {
            //로딩 게이지 조절
            float from = Loading_Fill.fillAmount;
            float to = Manager_SceneChange.Inst.ao.progress / 0.9f;
            float fillamount = Mathf.Lerp(from, to, Time.deltaTime);
            Loading_Fill.fillAmount = fillamount;
            yield return null;
        }
        // "로딩 중..."이 깜빡이는 효과 끄기
        Loading_Text.GetComponent<Animator>().SetTrigger("None");
        // "로딩 완료!"
        Loading_Text.text = Loading_Texts[1];
        // "아무키나 눌러주세요!"
        AnyKey_Text.SetActive(true);
    }
}
