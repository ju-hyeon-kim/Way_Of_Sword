using UnityEngine;

public class SettingIcon_Window : Window
{
    public void GoTitle_Button()
    {
        Question_Window QW = Dont_Destroy_Data.Inst.Question_Window;
        string s = "타이틀화면으로 돌아가시겠습니까?";
        QW.WindowSetting(s, YesButton_GoTitle);
        QW.gameObject.SetActive(true);
    }

    void YesButton_GoTitle()
    {
        Dont_Destroy_Data.Inst.gameObject.SetActive(false);
        Manager_SceneChange.Inst.ChangeScene("Title");
    }
}
