using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager_SceneChange : Singleton<Manager_SceneChange>
{
    public AsyncOperation ao;
    public bool LoadingChk = false; // ���� �ε� �������� �˻��ϴ� �Ұ�
    public Player_Main player; // �ڵ� ���ε�
    public MiniMapCam_Controller MiniMapCam_Controller; // �ڵ� ���ε�
    public string Before_Place = "";

    public void ChangeScene(string s)
    {
        //���̵� Ÿ���� TEMP�� ����
        for(int i = 0; i < Manager_Quest.Inst.Guide_Tartgets.Length; i++)
        {
            Manager_Quest.Inst.Guide_Tartgets[i] = transform;
        }

        //�̴ϸ� ������ ���� ����
        MiniMapCam_Controller.ChangeView_Setting(s);
        for (int i = 0; i < MiniMapCam_Controller.MiniMap_Icons.Length; i++)
        {
            MiniMapCam_Controller.MiniMap_Icons[i] = transform;
        }

        //�ε� �ڷ�ƾ
        if (!LoadingChk)
        {
            StartCoroutine(Loading(s));
        }
    }

    IEnumerator Loading(string s)
    {
        LoadingChk = true;
        yield return SceneManager.LoadSceneAsync("Loading"); // �ε� ���� ��ȯ �Ѵ� = �ε� ���� �����ش�.
        yield return StartCoroutine(LoadNextScene(s));
        LoadingChk = false;
    }

    IEnumerator LoadNextScene(string s)
    {       
        ao = SceneManager.LoadSceneAsync(s);
        ao.allowSceneActivation = false; //���ε��� ������ ������ ���� Ȱ��ȭ ��Ű�� �ʴ´�.

        //���ε��� �Ϸ�Ǹ� ����ȯ
        while (!ao.isDone)
        {
            if (ao.progress >= 0.9f)
            {
                if (Input.anyKeyDown)
                {
                    ao.allowSceneActivation = true;
                }
            }
            yield return null;
        }
        yield return null;
    }
}
