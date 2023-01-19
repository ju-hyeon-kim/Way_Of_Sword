using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MiniMapCam_Controller : MonoBehaviour
{

    public Camera myCam;
    public Transform Cam_Target;
    public Transform[] MiniMap_Icons = new Transform[10];

    public bool Target_inScreen;
    Vector3 myDir = Vector3.zero;
    float myDist = 0.0f;
    float minZoom = 40.0f;
    float maxZoom = 80.0f;
    float Zoom_IncrementValue = 5.0f; // �� ����ġ

    public void StartSetting()
    {
        myDir = transform.position - Cam_Target.position;
        myDist = myDir.magnitude;
        myDir.Normalize();
    }

    void Update()
    {
        transform.position = Cam_Target.position + myDir * myDist;
    }

    public void ChangeView_Setting(string s)
    {

        switch (s)
        {
            case "Village":
                break;
            case "Guild":
                //�÷��̾� ������ ������ ����
                MiniMap_Icons[0].localScale = new Vector3(2.0f, 2.0f, 1.0f);
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
            for (int i = 0; i < MiniMap_Icons.Length; i++)
            {
                MiniMap_Icons[i].localScale = new Vector3(MiniMap_Icons[i].localScale.x * 1.1f, MiniMap_Icons[i].localScale.y * 1.1f, 1);
            }
        }
    }

    /*public bool CheckTarget(GameObject target) // ķȭ�鿡 Ÿ�� ������Ʈ�� ���� �� Ʈ�縦 ��ȯ
    {
        Vector3 ScreenPoint = myCam.WorldToViewportPoint(target.transform.position);
        bool onScreen = ScreenPoint.z > 0 && ScreenPoint.x > 0 && ScreenPoint.x < 1 && ScreenPoint.y > 0 && ScreenPoint.y < 1;

        return onScreen;
    }*/
}
