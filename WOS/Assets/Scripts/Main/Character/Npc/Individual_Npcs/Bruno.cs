using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bruno : Npc
{
    [Header("-----Bruno-----")]
    public GameObject Meshs_OutLine;
    public GameObject Store_Window;

    public override void Outline_SetActive(bool b)
    {
        Meshs_OutLine.SetActive(b);
    }

    public override void Button_0and1_Set()
    {
        //Button0_Set(); -> 0버튼 기획 없음
        Button1_Set();
    }

    void Button1_Set()
    {
        Transform myButton = NpcTalk_Window.Buttons[1].transform;
        // 버튼 이름
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "상점";
        //Lock 활성화
        myButton.GetChild(1).gameObject.SetActive(true);
        //온클릭 적용
        myButton.GetComponent<Button>().onClick.AddListener(Store_Button);
        //Lock 비활성화
        myButton.GetChild(1).gameObject.SetActive(false);
        //버튼 활성화
        myButton.gameObject.SetActive(true);
    }

    void Store_Button()
    {
        //상점윈도우 키기 -> 위치설정(왼쪽)
        Store_Window.SetActive(true);
        Store_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, 130);
        //인벤윈도우 키기 -> 위치설정(오른쪽)
        GameObject Inventory_Window = Dont_Destroy_Data.Inst.Inventory_Window.gameObject;
        Inventory_Window.SetActive(true);
        Inventory_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 130);
    }
}
