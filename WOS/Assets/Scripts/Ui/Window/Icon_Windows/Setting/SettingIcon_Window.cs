using UnityEngine;

public class SettingIcon_Window : Window
{
    public void GoTitle_Button()
    {
        Question_Window QW = Dont_Destroy_Data.Inst.Question_Window;
        string s = "Ÿ��Ʋȭ������ ���ư��ðڽ��ϱ�?";
        QW.WindowSetting(s, YesButton_GoTitle);
        QW.gameObject.SetActive(true);
    }

    void YesButton_GoTitle()
    {
        Dont_Destroy_Data.Inst.gameObject.SetActive(false);
        Manager_SceneChange.Inst.ChangeScene("Title");
    }
}
