using System.Collections;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;


[System.Serializable]
public class Objects_Stroy2
{
    public GameObject Player;
}


public class Manager_Story2 : MonoBehaviour
{
    public Objects_Stroy2 Objects;
    float time = 0;

    enum STEP
    {
        Start, Move
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
        }
    }

    void StateProcess()
    {
        switch (NowStep)
        {
            case STEP.Start:
                time += Time.deltaTime;
                if(time > 2.0f)
                {
                    time = 0;
                    ChangeStep(STEP.Move);
                }
                break;
            case STEP.Move:
                break;
        }
    }

    private void Start()
    {
        ChangeStep(STEP.Start);
    }

    private void Update()
    {
        StateProcess();
    }
}