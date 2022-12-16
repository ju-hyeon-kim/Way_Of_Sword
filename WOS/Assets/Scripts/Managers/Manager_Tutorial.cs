using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;


[System.Serializable]
public class Objects_Tuto
{
    public GameObject Player;
    public GameObject BenderTalk_Window;
    public GameObject FadeOut;
}


public class Manager_Tutorial : MonoBehaviour
{
    public Objects_Tuto Objects;
    float time = 0;


    enum STEP
    {
        Start, Talk1, BasicAttack, End
    }

    [SerializeField]
    STEP NowStep;

    void ChangeStep(STEP s)
    {
        NowStep = s;

        switch (NowStep)
        {
            case STEP.Talk1:
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                break;
            case STEP.BasicAttack:
                Objects.BenderTalk_Window.SetActive(false);
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = true;
                break;
            case STEP.End:
                StartCoroutine(FadeOut_Anim());
                break;
        }
    }

    void StateProcess()
    {
        switch (NowStep)
        {
            case STEP.Start:
                time += Time.deltaTime;
                if (time > 1.0f)
                {
                    time = 0;
                    ChangeStep(STEP.Talk1);
                }
                break;
            case STEP.Talk1:
                if(Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 1)
                {
                    ChangeStep(STEP.BasicAttack);
                }
                break;
        }
    }

    private void Start()
    {
        Objects.BenderTalk_Window.SetActive(false);

        ChangeStep(STEP.Start);
    }

    private void Update()
    {
        StateProcess();
    }

    IEnumerator FadeOut_Anim()
    {
        while (Objects.FadeOut.GetComponent<Image>().fillAmount < 1)
        {
            Objects.FadeOut.GetComponent<Image>().fillAmount += Time.deltaTime;
            yield return null;
        }
        Manager_SceneChange.inst.ChangeScene("Tutorial");
    }
}