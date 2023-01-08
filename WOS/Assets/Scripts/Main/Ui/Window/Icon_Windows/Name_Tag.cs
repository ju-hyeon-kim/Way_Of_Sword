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
        Name_Tag[] myTabs = Tabs.GetComponentsInChildren<Name_Tag>();
        for(int i = 0; i < myTabs.Length; i++)
        {
            if (myTabs[i].transform.parent == myTab)
            {
                GetComponent<Image>().color = Color.white;
            }
            else
            {
                myTabs[i].GetComponent<Image>().color = UnshowColor;
            }
        }
    }
}
