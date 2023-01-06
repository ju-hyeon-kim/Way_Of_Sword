using System.Collections;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;


[System.Serializable]
public class Objects
{
    public GameObject Story_BG;
    public GameObject ExclamarionMark;
    public GameObject Player_Talk_Window;
    public GameObject GmTalk_Window;
    public GameObject Sword_Zone_Circle;
    public GameObject Door_Zone_Circle;
    public GameObject EventTalk_Window;
}


public class Manager_Story : MonoBehaviour
{
    public Objects Objects;
    public Animator Player;
    public Transform IconZone;
    public Item_Story Sword;
    public Collider Bed;
    public Collider Sword_zone;
    public AnimatorController Story1_2;

    Vector3 IconPos;
    IEnumerator Coroutine;
    float time = 0;
    string Text;

    enum STEP
    {
        Start, Sleep, Wakeup, Talk, Standup, Move, Event, Talk2, Event2, Talk3, Move2
    }

    [SerializeField]
    STEP NowStep;

    void ChangeStep(STEP s)
    {
        NowStep = s;

        switch (NowStep)
        {
            case STEP.Start:
                Player.SetTrigger("Sleep");
                break;
            case STEP.Sleep:
                StopCoroutine(Coroutine);
                break;
            case STEP.Wakeup:
                Player.SetTrigger("Wakeup");
                break;
            case STEP.Talk:
                Objects.Player_Talk_Window.SetActive(true);
                Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().CoTalking();
                break;
            case STEP.Standup:
                Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().TalkEnd = false;
                Objects.Player_Talk_Window.SetActive(false);
                Player.SetTrigger("Standup");
                break;
            case STEP.Move:
                Objects.GmTalk_Window.SetActive(true);
                Objects.Sword_Zone_Circle.SetActive(true);
                Bed.enabled = true;
                Player.gameObject.GetComponent<Player_Story1>().PlayerTurn = true;
                Sword.PlayerTurn = true;
                Player.applyRootMotion = false;
                Player.runtimeAnimatorController = Story1_2;
                break;
            case STEP.Event: //"어이!!"
                Objects.GmTalk_Window.SetActive(false);
                Objects.EventTalk_Window.SetActive(true);

                //플레이어 움직임 막기
                Player.gameObject.GetComponent<Player_Story1>().PlayerTurn = false;
                Player.gameObject.GetComponent<Player_Story1>().StopMove();
                break;
            case STEP.Talk2:
                //캐릭터가 문을 바라본다.
                Player.gameObject.GetComponent<Player_Story1>().PlayerTurn_rotdoor = true;

                //캐릭터 혼잣말 "아...귀청이야..."
                Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().Content_Num = 3;
                Objects.Player_Talk_Window.SetActive(true);
                Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().CoTalking();
                break;
            case STEP.Event2:
                //"빨랑 안나와?!"
                Text = Objects.EventTalk_Window.GetComponent<EventTalk_Window>().ReadyContents[1].Content;
                Objects.EventTalk_Window.GetComponent<EventTalk_Window>().Talk.text = Text;
                Objects.EventTalk_Window.GetComponent<EventTalk_Window>().Talk.fontSize = 160.0f;
                Objects.EventTalk_Window.SetActive(true);
                break;
            case STEP.Talk3:
                //"할 수 없군..."
                Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().Content_Num = 4;
                Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().CoTalking();
                break;
            case STEP.Move2: //문으로 이동
                //Player 대화창 제거
                Objects.Player_Talk_Window.SetActive(false);
                //Gm 대화창 생성
                Text = Objects.GmTalk_Window.GetComponent<GmTalk_Window>().ReadyContents[2].Content;
                Objects.GmTalk_Window.GetComponent<GmTalk_Window>().Talk.text = Text;
                Objects.GmTalk_Window.SetActive(true);
                //Door_Zone 생성
                Objects.Door_Zone_Circle.SetActive(true);
                //Player 움직임 제한 풀기
                Player.gameObject.GetComponent<Player_Story1>().PlayerTurn = true;
                break;
        }
    }

    void StateProcess()
    {
        switch (NowStep)
        {
            case STEP.Sleep:
                time += Time.deltaTime;
                if(time > 2.0f)
                {
                    IconPos = Camera.main.WorldToScreenPoint(IconZone.position);
                    Objects.ExclamarionMark.transform.position = IconPos;
                    Objects.ExclamarionMark.SetActive(true);
                    if (time > 5.0f)
                    {
                        time = 0;
                        Objects.ExclamarionMark.SetActive(false);
                        ChangeStep(STEP.Wakeup);
                    }
                }
                break;
            case STEP.Wakeup:
                if (Player.GetCurrentAnimatorStateInfo(0).IsName("Story.Wakeup"))
                {
                    Player.transform.Rotate(Vector3.up * Time.deltaTime * 70.0f); 
                    Player.transform.Translate(Vector3.forward * Time.deltaTime * 0.2f);
                }
                else if (Player.GetCurrentAnimatorStateInfo(0).IsName("Story.Sit"))
                {
                    time += Time.deltaTime;
                    if (time > 2.0f)
                    {
                        time = 0.0f;
                        ChangeStep(STEP.Talk);
                    }
                }
                break;
            case STEP.Talk:
                {
                    if(Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().Content_Num == 3)
                    {
                        ChangeStep(STEP.Standup);
                    }
                }
                break;
            case STEP.Standup:
                {
                    if(Player.GetCurrentAnimatorStateInfo(0).IsName("Story.Standup"))
                    {
                        Player.transform.Translate(Vector3.forward * Time.deltaTime * 0.2f);
                    }
                    else if(Player.GetCurrentAnimatorStateInfo(0).IsName("Story.Walk"))
                    {
                        Player.transform.Translate(Vector3.forward * Time.deltaTime * 0.8f);
                    }
                    else if (Player.GetCurrentAnimatorStateInfo(0).IsName("Story.Stand_Idle"))
                    {
                        ChangeStep(STEP.Move);
                    }
                }
                break;
            case STEP.Move:
                {
                    if(Player.GetComponent<Player_Story1>().Weapon_Back.activeSelf) // 검을 장착 했으면
                    {
                        time += Time.deltaTime;
                        if(time > 1.0f)
                        {
                            time = 0;
                            ChangeStep(STEP.Event);
                        }
                    }
                }
                break;
            case STEP.Event:
                {
                    time += Time.deltaTime;
                    if (time > 2.0f)
                    {
                        time = 0;
                        Objects.EventTalk_Window.SetActive(false);
                        ChangeStep(STEP.Talk2);
                    }
                }
                break;
            case STEP.Talk2:
                {
                    if(Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().Step_Event2)
                    {
                        ChangeStep(STEP.Event2);
                    }
                }
                break;
            case STEP.Event2:
                {
                    time += Time.deltaTime;
                    if (time > 2.0f)
                    {
                        time = 0;
                        Objects.EventTalk_Window.SetActive(false);
                        ChangeStep(STEP.Talk3);
                    }
                }
                break;
            case STEP.Talk3:
                {
                    if (Objects.Player_Talk_Window.GetComponent<PlayerTalk_Window_S1>().Step_Move2)
                    {
                        ChangeStep(STEP.Move2);
                    }
                }
                break;
        }
    }

    private void Start()
    {
        Objects.Story_BG.SetActive(true);
        Objects.ExclamarionMark.SetActive(false);
        Objects.Player_Talk_Window.SetActive(false);
        Objects.GmTalk_Window.SetActive(false);
        Objects.Sword_Zone_Circle.SetActive(false);
        Objects.Door_Zone_Circle.SetActive(false);
        Objects.EventTalk_Window.SetActive(false);

        ChangeStep(STEP.Start); // 해당 문구는 여기 두었다가 스토리 텍스트 애니메이션이 끝나면 실행하는걸로 변경 필요

        Coroutine = CheckClick();
        StartCoroutine(Coroutine);
    }

    private void Update()
    {
        StateProcess();
    }

    IEnumerator CheckClick()
    {
        while(true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Objects.Story_BG.SetActive(false);
                ChangeStep(STEP.Sleep);
            }
            yield return null;
        }
    }
}