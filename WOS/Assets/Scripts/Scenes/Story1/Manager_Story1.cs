using System.Collections;
using UnityEngine;

public enum STEP
{
    None, Start, Sword, Talk, Standup, Move, Event, Talk2, Event2, Talk3, Move2
}

public class Manager_Story1 : MonoBehaviour
{
    public GameObject StoryTelling;
    public Player_Story1 Player;
    public GameObject Player_Talk_Window;
    public Gm_Message Gm_Message;
    public Sword_Zone Sword_Zone;

    [SerializeField]
    STEP NowStep = STEP.None;

    public void ChangeStep(STEP s)
    {
        NowStep = s;

        switch (NowStep)
        {
            case STEP.Start:
                Player.Sleep();
                break;
            case STEP.Sword:
                Gm_Message.gameObject.SetActive(true);
                Gm_Message.ShowMessage(0);
                Sword_Zone.gameObject.SetActive(true);
                Player.GetComponent<Animator>().SetTrigger("Standup");
                Player.DownPos();
                break;
        }
    }

    void StateProcess()
    {
        switch (NowStep)
        {
            case STEP.Start:
                break;
        }
    }

    private void Update()
    {
        StateProcess();
    }

    public void Start_Story1()
    {
        StartCoroutine(CheckClick());
    }

    IEnumerator CheckClick()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StoryTelling.SetActive(false);
                ChangeStep(STEP.Start);
            }
            yield return null;
        }
    }

    //테스트후 => 스타트함수 삭제필요
    private void Start()
    {
        StoryTelling.SetActive(false);
        ChangeStep(STEP.Start);
    }

}