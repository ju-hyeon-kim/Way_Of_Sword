using TMPro;
using UnityEngine;

public class TeleportQuestion_Window : MonoBehaviour
{
    public TMP_Text Question_Text;
    public GameObject Map_Window;
    public NowPos_Icon NowPos_Icon;

    GameObject place;

    public void Place_Check(GameObject icon)
    {
        place = icon;
        switch (place.name)
        {
            case "Village":
                Question_Text.text = "������ �̵� �Ͻðڽ��ϱ�?";
                break;
            case "Forest":
                Question_Text.text = "������ ������ �̵� �Ͻðڽ��ϱ�?";
                break;
        }
    }

    public void Yes_Button()
    {
        //����ȯ
        Dont_Destroy_Data.Inst.Manager_Quest.SceneChange();
        Dont_Destroy_Data.Inst.Manager_Cams.MiniMapCam_Controller.SceneChange();
        Manager_SceneChange.Inst.ChangeScene(place.name);

        // ĳ������ ������ġ�� ������ ǥ��
        NowPos_Icon.ChangeNowPos(place.transform);

        this.gameObject.SetActive(false);
        Map_Window.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void No_Button()
    {
        gameObject.SetActive(false);
        NowPos_Icon.ReturnPos();
    }
}
