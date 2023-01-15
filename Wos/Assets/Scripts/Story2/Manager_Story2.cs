using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;


[System.Serializable]
public class Objects_Stroy2
{
    public GameObject Player;
    public GameObject BenderTalk_Window;
    public GameObject PlayerTalk_Window;
    public GameObject FadeOut;
}


public class Manager_Story2 : MonoBehaviour
{
    public Objects_Stroy2 Objects;
    float time = 0;


    enum STEP
    {
        Start, Move, Talk, End
    }

    [SerializeField]
    STEP NowStep;

    void ChangeStep(STEP s)
    {
        NowStep = s;

        switch (NowStep)
        {
            case STEP.Start:
                break;
            case STEP.Move:
                Objects.Player.GetComponent<Player_Story2>().Movement("Move_Door");
                break;
            case STEP.Talk:
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_S2>().NextTalk();
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
                if(time > 1.0f)
                {
                    time = 0;
                    ChangeStep(STEP.Move);
                }
                break;
            case STEP.Move:
                if (Objects.Player.GetComponent<Player_Story2>().isArrival)
                {
                    ChangeStep(STEP.Talk);
                }
                break;
            case STEP.Talk:
                if(Objects.PlayerTalk_Window.GetComponent<PlayerTalk_Window_S2>().SceneEnd == true)
                {
                    ChangeStep(STEP.End);
                }
                break;
        }
    }

    private void Start()
    {
        Objects.BenderTalk_Window.SetActive(false);
        Objects.PlayerTalk_Window.SetActive(false);

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