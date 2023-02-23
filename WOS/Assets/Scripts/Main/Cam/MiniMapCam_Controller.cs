using System.Collections;
using UnityEngine;

public class MiniMapCam_Controller : MonoBehaviour
{

    public Camera myCam;
    public Transform Cam_Target;
    public Transform Player_Icon;
    public Transform[] MiniMap_Icons; // [0]�� �׻� �÷��̾� ������

    Vector3 myDir = Vector3.zero;
    float myDist = 0.0f;
    float minZoom = 40.0f;
    float maxZoom = 80.0f;
    float Zoom_IncrementValue = 5.0f; // �� ����ġ

    private void Awake()
    {
        Manager_SceneChange.Inst.MiniMapCam_Controller = this;
    }

    public void StartSetting()
    {
        myDir = transform.position - Cam_Target.position;
        myDist = myDir.magnitude;
        myDir.Normalize();

        StartCoroutine(Following_CamTarget());
    }

    IEnumerator Following_CamTarget()
    {
        while (true)
        {
            transform.position = Cam_Target.position + myDir * myDist;
            yield return null;
        }
    }

    public void ChangeView_Setting(string s)
    {
        switch (s)
        {
            case "Village":
                Player_Icon.localScale = new Vector3(8.0f, 8.0f, 1.0f);
                //�� �Ÿ� ����
                myDist = 60.0f;
                //�� ���Ѱ� ����
                minZoom = 40.0f;
                maxZoom = 80.0f;
                //�� ����ġ ����
                Zoom_IncrementValue = 5.0f;
                break;
            case "Guild":
                //�÷��̾� ������ ������ ����
                Player_Icon.localScale = new Vector3(2.0f, 2.0f, 1.0f);
                //�� �Ÿ� ����
                myDist = 15.0f;
                //�� ���Ѱ� ����
                minZoom = 10.0f;
                maxZoom = 20.0f;
                //�� ����ġ ����
                Zoom_IncrementValue = 2.0f;
                break;
        }
    }

    public void ZoomIn()
    {
        myDist -= Zoom_IncrementValue;
        myDist = Mathf.Clamp(myDist, minZoom, maxZoom); // �� ���Ѱ�
        if (myDist > minZoom + 1 && myDist < maxZoom - 1)
        {
            Player_Icon.localScale = new Vector3(Player_Icon.localScale.x * 0.9f, Player_Icon.localScale.y * 0.9f, 1);
            for (int i = 0; i < MiniMap_Icons.Length; i++)
            {
                MiniMap_Icons[i].localScale = new Vector3(MiniMap_Icons[i].localScale.x * 0.9f, MiniMap_Icons[i].localScale.y * 0.9f, 1);
            }
        }
    }

    public void ZoomOut()
    {
        myDist += Zoom_IncrementValue;
        myDist = Mathf.Clamp(myDist, minZoom, maxZoom); // �� ���Ѱ�
        if (myDist > minZoom + 1 && myDist < maxZoom - 1)
        {
            Player_Icon.localScale = new Vector3(Player_Icon.localScale.x * 1.1f, Player_Icon.localScale.y * 1.1f, 1);
            for (int i = 0; i < MiniMap_Icons.Length; i++)
            {
                MiniMap_Icons[i].localScale = new Vector3(MiniMap_Icons[i].localScale.x * 1.1f, MiniMap_Icons[i].localScale.y * 1.1f, 1);
            }
        }
    }

    public bool Target_inScreen(GameObject target) // ķȭ�鿡 Ÿ�� ������Ʈ�� ���� �� Ʈ�縦 ��ȯ
    {
        Vector3 ScreenPoint = myCam.WorldToViewportPoint(target.transform.position);
        bool onScreen = ScreenPoint.z > 0 && ScreenPoint.x > 0 && ScreenPoint.x < 1 && ScreenPoint.y > 0 && ScreenPoint.y < 1;

        return onScreen;
    }

    public void SceneChange()
    {
        for (int i = 0; i < MiniMap_Icons.Length; ++i)
        {
            MiniMap_Icons[i] = this.transform;
        }
    }
}
