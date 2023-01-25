using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question_Window : MonoBehaviour
{
    public TMP_Text Question_Text;
    public GameObject Map_Window;
    string place_name = "";

    public void Place_Check(string s)
    {
        
        place_name = s;
        switch (place_name)
        {
            case "Village":
                Question_Text.text = "마을로 이동 하시겠습니까?";
                break;
            case "Forest":
                Question_Text.text = "벌레의 숲으로 이동 하시겠습니까?";
                break;
        }
    }

    public void Yes_Button()
    {
        Manager_SceneChange.Inst.ChangeScene(place_name);
    }

    public void No_Button()
    {
        gameObject.SetActive(false);
    }
}
