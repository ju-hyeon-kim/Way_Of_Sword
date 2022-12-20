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
    public GameObject GMTalk_Window;
    public GameObject Zone_Circle;
    public GameObject FadeOut;
}


public class Manager_Tutorial : MonoBehaviour
{
    public Objects_Tuto Objects;
    public bool BasicAttack_end = false;
    float time = 0;


    enum STEP
    {
        Start, Talk1, BasicAttack, End, Talk2, ComboAttack, Talk3, SkillAttack
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
                //���� Talk ����
                Objects.BenderTalk_Window.SetActive(false);
                //GM TAlk �ѱ�
                Objects.GMTalk_Window.SetActive(true);
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().NextTalk();
                //���� �� ��Ŭ Ű��
                Objects.Zone_Circle.SetActive(true);
                //�÷��̾� �� Ű��
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = true;
                break;
            case STEP.Talk2:
                //���� Talk Ű��
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                //GM TalK ����
                Objects.GMTalk_Window.SetActive(false);
                //���� �� ��Ŭ ����
                Objects.Zone_Circle.SetActive(false);
                //�÷��̾� �� ����
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = false;
                Objects.Player.GetComponent<Animator>().SetTrigger("ComboFail"); // ���̵� ���·� �ٲٱ�
                break;
            case STEP.ComboAttack:
                //���� Talk ����
                Objects.BenderTalk_Window.SetActive(false);
                //GM TAlk �ѱ�
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Content_Num++;
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Talk.fontSize = 23;
                Objects.GMTalk_Window.SetActive(true);
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().NextTalk();
                //���� �� ��Ŭ Ű��
                Objects.Zone_Circle.SetActive(true);
                //�÷��̾� �� Ű��
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = true;
                break;
            case STEP.Talk3:
                //���� Talk Ű��
                Objects.BenderTalk_Window.SetActive(true);
                Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().NextTalk();
                //GM TalK ����
                Objects.GMTalk_Window.SetActive(false);
                //���� �� ��Ŭ ����
                Objects.Zone_Circle.SetActive(false);
                //�÷��̾� �� ����
                Objects.Player.GetComponent<Player_Tuto>().PlayerTurn = false;
                Objects.Player.GetComponent<Animator>().SetTrigger("ComboFail"); // ���̵� ���·� �ٲٱ�
                break;
            case STEP.SkillAttack:
                //���� Talk ����
                Objects.BenderTalk_Window.SetActive(false);
                //GM TAlk �ѱ�
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Content_Num++;
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().Talk.fontSize = 23;
                Objects.GMTalk_Window.SetActive(true);
                Objects.GMTalk_Window.GetComponent<GmTalk_Window>().NextTalk();
                //���� �� ��Ŭ Ű��
                Objects.Zone_Circle.SetActive(true);
                //�÷��̾� �� Ű��
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
            case STEP.BasicAttack:
                {
                    if(BasicAttack_end)
                    {
                        ChangeStep(STEP.Talk2);
                    }
                }
                break;
            case STEP.Talk2:
                if (Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 2)
                {
                    ChangeStep(STEP.ComboAttack);
                }
                break;
            case STEP.ComboAttack:
                // �޺������� ����Ǹ� ü���� ����
                if(Objects.Player.GetComponent<Player_Tuto>().ComboAttack_Success == true)
                {
                    ChangeStep(STEP.Talk3);
                }
                break;
            case STEP.Talk3:
                if (Objects.BenderTalk_Window.GetComponent<BenderTalk_Window_T>().Content_Num == 3)
                {
                    ChangeStep(STEP.SkillAttack);
                }
                break;
        }
    }

    private void Start()
    {
        Objects.BenderTalk_Window.SetActive(false);
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
        Manager_SceneChange.inst.ChangeScene("Tutorial");
    }
}