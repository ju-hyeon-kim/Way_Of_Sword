using UnityEngine;

public class Manager_Title : MonoBehaviour
{
    public Question_Window Question_Window;
    public GameObject Load_Window;
    public GameObject Option_Window;

    private void Start()
    {
        Manager_Sound.Inst.BgmSource.OnPlay(0);
    }

    public void NewGame_Button()
    {
        Question_Window.WindowSetting("새로운 여정을 떠나시겠습니까?", YesButton_ofNewGame);
        Question_Window.gameObject.SetActive(true);
    }

    

    public void Load_Button()
    {
        Load_Window.SetActive(true);
    }

    public void Option_Button()
    {
        Option_Window.SetActive(true);
    }

    public void Exit_Button()
    {
        Question_Window.WindowSetting("게임을 종료하시겠습니까?", YesButton_ofExit);
        Question_Window.gameObject.SetActive(true);
    }

    void YesButton_ofNewGame()
    {
        Manager_SceneChange.Inst.ChangeScene("Village");
    }

    void YesButton_ofExit()
    {
        Application.Quit();
    }
}
