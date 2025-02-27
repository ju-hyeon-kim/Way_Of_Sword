using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_SceneChange : Singleton<Manager_SceneChange>
{
    public AsyncOperation ao;
    public bool LoadingChk = false; // 현재 로딩 중인지를 검사하는 불값
    public MiniMapCam_Controller MiniMapCam_Controller = null; // 자동 바인딩
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
                //미니맵 아이콘 설정 변경
                MiniMapCam_Controller.ChangeView_Setting(s);
            }
        }

        //로딩 코루틴
        if (!LoadingChk)
        {
            StartCoroutine(Loading(s));
        }
    }

    IEnumerator Loading(string s)
    {
        LoadingChk = true;
        yield return SceneManager.LoadSceneAsync("Loading"); // 로딩 씬을 반환 한다 = 로딩 씬을 보여준다.
        yield return StartCoroutine(LoadNextScene(s));
        LoadingChk = false;
    }

    IEnumerator LoadNextScene(string s)
    {
        ao = SceneManager.LoadSceneAsync(s);
        ao.allowSceneActivation = false; //씬로딩이 끝나기 전까지 씬을 활성화 시키지 않는다.

        //씬로딩이 완료되면 씬전환
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
