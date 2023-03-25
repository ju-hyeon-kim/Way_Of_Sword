using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_SceneChange : Singleton<Manager_SceneChange>
{
    public AsyncOperation ao;
    public bool LoadingChk = false; // ���� �ε� �������� �˻��ϴ� �Ұ�
    public MiniMapCam_Controller MiniMapCam_Controller = null; // �ڵ� ���ε�
    public string Before_Place = "";

    public void ChangeScene(string s)
    {
        if (SceneManager.GetActiveScene().name != "Title")
        {
            Transform[] targets = Dont_Destroy_Data.Inst.Manager_Quest.Guide_Targets;
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i] = this.transform;
            }

            if (Dont_Destroy_Data.Inst != null)
            {
                //�̴ϸ� ������ ���� ����
                MiniMapCam_Controller.ChangeView_Setting(s);
            }
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
