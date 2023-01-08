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
        //���� ������ �ڽ� ������Ʈ�� �̵���
        myTab.SetAsLastSibling();

        //�������� ��Ӱ� ����� �ڽ��� ��� ����
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
