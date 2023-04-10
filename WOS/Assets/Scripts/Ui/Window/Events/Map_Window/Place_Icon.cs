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
            string s = $"{place}(으)로 이동 하시겠습니까";
            QW.WindowSetting(s,YesButton_OnClick, NoButton_OnClick);
            QW.gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) // 마우스 포지션이 아이콘 안으로 들어왔을때
    {
        //sfx
        Manager_Sound.Inst.SfxSource.OnPlay(3);
        myLabel_Image.SetBool("Open", true);
    }

    public void OnPointerExit(PointerEventData eventData) // 마우스 포지션이 아이콘 밖으로 빠져나갈 때
    {
        myLabel_Image.SetBool("Open", false);
    }

    void YesButton_OnClick()
    {
        //씬전환
        Dont_Destroy_Data.Inst.Manager_Quest.SceneChange();
        Dont_Destroy_Data.Inst.Manager_Cams.MiniMapCam_Controller.SceneChange();
        string s = "";
        switch(place)
        {
            case "마을":
                s = "Village";
                break;
            case "벌레의숲":
                s = "Forest";
                break;
        }
        Manager_SceneChange.Inst.ChangeScene(s);

        // 캐릭터의 현재위치를 지도에 표시
        NowPos_Icon.ChangeNowPos(this.transform);
        Map_Window.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void NoButton_OnClick()
    {
        NowPos_Icon.ReturnPos();
    }
}
