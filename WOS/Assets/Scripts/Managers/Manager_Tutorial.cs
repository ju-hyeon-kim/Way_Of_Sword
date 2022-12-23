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
    public GameObject PlayerTalk_Window;
    public GameObject GMTalk_Window;
    public GameObject Zone_Circle;
    public GameObject FadeOut;
    public GameObject HP_of_Dummy;
    public GameObject Dummy;
}


public class Manager_Tutorial : MonoBehaviour
{
    public Objects_Tuto Objects;
    public bool BasicAttack_end = false;
    float time = 0;


    enum STEP
    {
        Start, Talk_B1, BasicAttack, End, Talk_B2, ComboAttack, Talk_B3, SkillAttack, Talk_B4, KillDummy, Talk_B5, 
        Talk_P1, Talk_B6, Talk_P2
    }

    [SerializeField]
    STEP NowStep;

    void ChangeStep(STEP s)
    {
        NowStep = s;

        switch (NowStep)
        {
            case STEP.Talk_B1:
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                break;
            case STEP.BasicAttack:
                //벤더 Talk 끄기
                Objects.BenderTalk_Window.SetActive(false);
                //GM TAlk 켜기
                Objects.GMTalk_Window.SetActive(true);
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().NextTalk();
                //더미 존 써클 키기
                Objects.Zone_Circle.SetActive(true);
                //플레이어 턴 키기
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = true;
                break;
            case STEP.Talk_B2:
                //벤더 Talk 키기
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                //GM TalK 끄기
                Objects.GMTalk_Window.SetActive(false);
                //더미 존 써클 끄기
                Objects.Zone_Circle.SetActive(false);
                //플레이어 턴 끄기
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = false;
                //Objects.Player.GetComponent<Animator>().SetTrigger("ComboFail"); // 아이들 상태로 바꾸기
                break;
            case STEP.ComboAttack:
                //벤더 Talk 끄기
                Objects.BenderTalk_Window.SetActive(false);
                //GM TAlk 켜기
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Content_Num++;
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Talk.fontSize = 23;
                Objects.GMTalk_Window.SetActive(true);
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().NextTalk();
                //더미 존 써클 키기
                Objects.Zone_Circle.SetActive(true);
                //플레이어 턴 키기
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = true;
                break;
            case STEP.Talk_B3:
                //벤더 Talk 키기
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                //GM TalK 끄기
                Objects.GMTalk_Window.SetActive(false);
                //더미 존 써클 끄기
                Objects.Zone_Circle.SetActive(false);
                //플레이어 턴 끄기
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = false;
                //Objects.Player.GetComponent<Animator>().SetBool("Run", false); // 아이들 상태로 바꾸기
                break;
            case STEP.SkillAttack:
                //스킬 사용 가능
                Objects.Player.GetComponent<Player_Tuto>().SkillAttack_Start = true;
                //Objects.Player.GetComponent<Player_Tuto>().isSkillCool = false;
                //벤더 Talk 끄기
                Objects.BenderTalk_Window.SetActive(false);
                //GM TAlk 켜기
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Content_Num++;
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Talk.fontSize = 23;
                Objects.GMTalk_Window.SetActive(true);
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().NextTalk();
                //더미 존 써클 키기
                Objects.Zone_Circle.SetActive(true);
                //플레이어 턴 키기
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = true;
                break;
            case STEP.Talk_B4:
                //벤더 Talk 키기
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                //GM TalK 끄기
                Objects.GMTalk_Window.SetActive(false);
                //더미 존 써클 끄기
                Objects.Zone_Circle.SetActive(false);
                //플레이어 턴 끄기
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = false;
                break;
            case STEP.KillDummy:
                //벤더 Talk 끄기
                Objects.BenderTalk_Window.SetActive(false);
                //GM TAlk 켜기
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Content_Num++;
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Talk.fontSize = 25;
                Objects.GMTalk_Window.SetActive(true);
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().NextTalk();
                //더미 존 써클 키기
                Objects.Zone_Circle.SetActive(true);
                //플레이어 턴 키기
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = true;
                //더미에 데미지 들어갈수 있게 설정
                Objects.Dummy.GetComponent<Dummy>().Step_KillDummy = true;
                Objects.HP_of_Dummy.SetActive(true);
                break;
            case STEP.Talk_B5:
                //벤더 Talk 키기
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                //GM TalK 끄기
                Objects.GMTalk_Window.SetActive(false);
                //더미 존 써클 끄기
                Objects.Zone_Circle.SetActive(false);
                //플레이어 턴 끄기
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = false;
                break;
            case STEP.Talk_P1:
                //벤더 Talk 끄기
                Objects.BenderTalk_Window.SetActive(false);
                //P Talk 켜기
                Objects.PlayerTalk_Window.SetActive(true);
                Objects.PlayerTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                break;
            case STEP.Talk_B6:
                //P Talk 끄기
                Objects.PlayerTalk_Window.SetActive(false);
                //벤더 Talk 켜기
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                break;
            case STEP.Talk_P2:
                //벤더 Talk 끄기
                Objects.BenderTalk_Window.SetActive(false);
                //P Talk 켜기
                Objects.PlayerTalk_Window.SetActive(true);
                Objects.PlayerTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
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
                    ChangeStep(STEP.Talk_B1);
                }
                break;
            case STEP.Talk_B1:
                if(Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 1)
                {
                    ChangeStep(STEP.BasicAttack);
                }
                break;
            case STEP.BasicAttack:
                {
                    if(BasicAttack_end)
                    {
                        ChangeStep(STEP.Talk_B2);
                    }
                }
                break;
            case STEP.Talk_B2:
                if (Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 2)
                {
                    ChangeStep(STEP.ComboAttack);
                }
                break;
            case STEP.ComboAttack:
                // 콤보공격이 실행되면 체인지 스탭
                if(Objects.Player.GetComponent<Player_Tuto>().ComboAttack_Success == true)
                {
                    ChangeStep(STEP.Talk_B3);
                }
                break;
            case STEP.Talk_B3:
                if (Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 3)
                {
                    ChangeStep(STEP.SkillAttack);
                }
                break;
            case STEP.SkillAttack:
                if(Objects.Player.GetComponent<Player_Tuto>().SkillAttack_Success == true)
                {
                    ChangeStep(STEP.Talk_B4);
                }
                break;
            case STEP.Talk_B4:
                if (Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 4)
                {
                    ChangeStep(STEP.KillDummy);
                }
                break;
            case STEP.KillDummy:
                if (Objects.Dummy.GetComponent<Dummy>().isDead == true)
                {
                    ChangeStep(STEP.Talk_B5);
                }
                break;
            case STEP.Talk_B5:
                if (Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 5)
                {
                    ChangeStep(STEP.Talk_P1);
                }
                break;
            case STEP.Talk_P1:
                if (Objects.PlayerTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 1)
                {
                    ChangeStep(STEP.Talk_B6);
                }
                break;
            case STEP.Talk_B6:
                if (Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 6)
                {
                    ChangeStep(STEP.Talk_P2);
                }
                break;
            case STEP.Talk_P2:
                if (Objects.PlayerTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 2)
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
        Objects.GMTalk_Window.SetActive(false);
        Objects.Zone_Circle.SetActive(false);

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
        Manager_SceneChange.inst.ChangeScene("Village");
    }
}