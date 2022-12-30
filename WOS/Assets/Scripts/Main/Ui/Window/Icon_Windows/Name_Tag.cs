using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Name_Tag : MonoBehaviour
{
    public Transform myTab;
    Color UnshowColor = Color.gray;

    Transform Tabs;

    private void Start()
    {
        Tabs = myTab.parent;
    }

    public void ShowTab()
    {
        //가장 마지막 자식 오브젝트로 이동함
        myTab.SetAsLastSibling();

        //형제들은 어둡게 만들고 자신은 밝게 만듬
        GetComponent<Image>().color = Color.white;
        Tabs.GetChild(0).GetChild(0).GetComponent<Image>().color = UnshowColor; // 0번째 자식
        Tabs.GetChild(1).GetChild(0).GetComponent<Image>().color = UnshowColor; // 1번째 자식
        Tabs.GetChild(2).GetChild(0).GetComponent<Image>().color = UnshowColor; // 2번째 자식
    }
}
