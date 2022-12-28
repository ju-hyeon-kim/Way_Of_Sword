using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcTalk_Window : MonoBehaviour
{
    public Image Profile;
    public TMP_Text Name;
    public TMP_Text Talk;
    public Button ReturnButton;
    public MainCam_Controller MainCam;

    public string SaveText = "";
    string SaveString = "";

    public void OnTyping()
    {
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        for (int i = 0; i < SaveText.Length; ++i)
        {
            SaveString += SaveText[i];
            Talk.text = SaveString;
            yield return new WaitForSeconds(0.1f); // 0.1�ʴ� �� ���� Ÿ����
        }
        //Save strings �ʱ�ȭ
        SaveText = "";
        SaveString = "";

        //��ư Ȱ��ȭ
        ReturnButton.gameObject.SetActive(true);
    }

    public void OnReturnButton()
    {
        ReturnButton.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        // ī�޶� ���� �������
        MainCam.ReturnView();
    }
}
