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
        GetComponent<Image>().color = Color.white;
        Tabs.GetChild(0).GetChild(0).GetComponent<Image>().color = UnshowColor; // 0��° �ڽ�
        Tabs.GetChild(1).GetChild(0).GetComponent<Image>().color = UnshowColor; // 1��° �ڽ�
        Tabs.GetChild(2).GetChild(0).GetComponent<Image>().color = UnshowColor; // 2��° �ڽ�
    }
}
