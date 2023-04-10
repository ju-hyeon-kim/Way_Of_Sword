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
    public GameObject Strengthen_Window;

    public override void Outline_SetActive(bool b)
    {
        Meshs_OutLine.SetActive(b);
    }

    public override void Button0and1_ofChild()
    {
        Button0_Set();
        Button1_Set();
    }

    void Button0_Set()
    {
        Transform myButton = NpcTalk_Window.Buttons[0].transform;
        // 버튼 이름
        myButton.GetChild(0).GetComponent<TMP_Text>().text = "강화";
        //Lock 활성화
        myButton.GetChild(1).gameObject.SetActive(true);
        //온클릭 적용
        myButton.GetComponent<Button>().onClick.AddListener(Enhancement_Button);
        myButton.GetComponent<Button>().onClick.AddListener(Play_ClickSound);
        //Lock 비활성화
        myButton.GetChild(1).gameObject.SetActive(false);
        //버튼 활성화
        myButton.gameObject.SetActive(true);
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
        myButton.GetComponent<Button>().onClick.AddListener(Play_ClickSound);
        //Lock 비활성화
        myButton.GetChild(1).gameObject.SetActive(false);
        //버튼 활성화
        myButton.gameObject.SetActive(true);
    }

    void Enhancement_Button()
    {
        //상점윈도우 끄기
        Store_Window.SetActive(false);
        //강화윈도우 키기 -> 위치설정(왼쪽)
        Strengthen_Window.SetActive(true);
        Strengthen_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, 130);
        //인벤윈도우 키기 -> 위치설정(오른쪽)
        GameObject Inventory_Window = Dont_Destroy_Data.Inst.Inventory_Window.gameObject;
        Inventory_Window.SetActive(true);
        Inventory_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 130);
    }

    void Store_Button()
    {
        //강화윈도우 끄기
        Strengthen_Window.SetActive(false);
        //상점윈도우 키기 -> 위치설정(왼쪽)
        Store_Window.SetActive(true);
        Store_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, 130);
        //인벤윈도우 키기 -> 위치설정(오른쪽)
        GameObject Inventory_Window = Dont_Destroy_Data.Inst.Inventory_Window.gameObject;
        Inventory_Window.SetActive(true);
        Inventory_Window.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, 130);
    }

    public override void Button2_OnClick_ofChild()
    {
        Store_Window.SetActive(false);
        Dont_Destroy_Data.Inst.Inventory_Window.gameObject.SetActive(false);
    }

    public override void Child_Reaction()
    {
        //사운드
        GetComponent<AudioSource>().Play();
    }
}
