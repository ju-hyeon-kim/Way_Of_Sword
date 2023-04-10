using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Place_Icon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Animator myLabel_Image;
    public GameObject myLock;
    public NowPos_Icon NowPos_Icon;
    public GameObject Map_Window;

    public string place;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SceneManager.GetActiveScene().name != gameObject.name && myLock.activeSelf == false)
        {
            //sfx
            Manager_Sound.Inst.SfxSource.OnPlay(0);

            NowPos_Icon.ChangePos(this.transform);

            //QW
            Question_Window QW = Dont_Destroy_Data.Inst.Question_Window;
            string s = $"{place}(��)�� �̵� �Ͻðڽ��ϱ�";
            QW.WindowSetting(s,YesButton_OnClick, NoButton_OnClick);
            QW.gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) // ���콺 �������� ������ ������ ��������
    {
        //sfx
        Manager_Sound.Inst.SfxSource.OnPlay(3);
        myLabel_Image.SetBool("Open", true);
    }

    public void OnPointerExit(PointerEventData eventData) // ���콺 �������� ������ ������ �������� ��
    {
        myLabel_Image.SetBool("Open", false);
    }

    void YesButton_OnClick()
    {
        //����ȯ
        Dont_Destroy_Data.Inst.Manager_Quest.SceneChange();
        Dont_Destroy_Data.Inst.Manager_Cams.MiniMapCam_Controller.SceneChange();
        string s = "";
        switch(place)
        {
            case "����":
                s = "Village";
                break;
            case "�����ǽ�":
                s = "Forest";
                break;
        }
        Manager_SceneChange.Inst.ChangeScene(s);

        // ĳ������ ������ġ�� ������ ǥ��
        NowPos_Icon.ChangeNowPos(this.transform);
        Map_Window.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void NoButton_OnClick()
    {
        NowPos_Icon.ReturnPos();
    }
}
