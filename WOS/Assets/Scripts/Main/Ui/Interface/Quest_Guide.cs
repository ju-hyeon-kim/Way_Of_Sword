using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_Guide : MonoBehaviour
{
    public Transform Player;
    public Transform MiniMap_Camera;
    public MiniMapCam_Controller MiniMapCam_Controller;

    Coroutine CoGuiding;

    IEnumerator Guiding()
    {
        int Q_Num = Manager_Quest.Inst.NowQuest.Quest_Number;
        while (true)
        {
            Transform Target = Manager_Quest.Inst.Guide_Tartgets[Q_Num];

            if (MiniMapCam_Controller.Target_inScreen(Target.gameObject) == false)
            {
                transform.GetChild(0).gameObject.SetActive(true);

                Vector3 dir = Target.position - Player.position;
                dir.y = 0;
                dir.Normalize();

                float Angle = Vector3.Angle(MiniMap_Camera.transform.up, dir);

                float rotDir = 1.0f; // 1 or -1 => 왼쪽으로 돌지 오른쪽으로 돌지 구분
                if (Vector3.Dot(MiniMap_Camera.transform.right, dir) > 0.0f)
                {
                    rotDir = -rotDir;
                }
                transform.rotation = Quaternion.Euler(0, 0, Angle * rotDir);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    public void StartGuiding()
    {
        CoGuiding = StartCoroutine(Guiding());
    }

    public void StopGuiding()
    {
        StopCoroutine(CoGuiding);
    }

    public void Change_Quest()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        StartGuiding();
    }

    public void Complete_Quest()
    {
        StopGuiding();
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
