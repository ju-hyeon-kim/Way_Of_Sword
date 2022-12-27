using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Npc : MonoBehaviour
{
    public Npc_Data Datas;

    public MainCam_Controller MainCam;
    public Material OutLine;
    public Renderer[] RendererList;
    public GameObject NpcName_Label;
    public Transform NameLabel_Zone;
    public GameObject NpcTalk_Window;
    public bool isEvent = false;

    List<Material[]> Origin = new List<Material[]>();
    Vector3 OrgForward;
    
    
    private void Start()
    {
        OrgForward = Datas.myForward.position;

        for (int i = 0; i < RendererList.Length; ++i)
        {
            Origin.Add(RendererList[i].materials);
        }
    }

    private void Update()
    {
        if(!isEvent)
        {
            //마우스 포지션과 상호작용(아웃라인)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("Npc")))
            {
                //아웃라인 적용
                for (int i = 0; i < RendererList.Length; ++i)
                {
                    Material[] Change = new Material[2];
                    Change[0] = RendererList[i].materials[0];
                    Change[1] = OutLine;
                    RendererList[i].materials = Change;
                }

                //이름 라벨 켜기
                NpcName_Label.SetActive(true);
                NpcName_Label.GetComponentInChildren<TMP_Text>().text = Datas.Name;
                NpcName_Label.transform.position = Camera.main.WorldToScreenPoint(NameLabel_Zone.position);
            }
            else
            {
                NameOutLine_false(); //아웃라인 해제 & 네임라벨 끄기
            }
        }
        else // 이벤트 발생시
        {
            NameOutLine_false(); //아웃라인 해제 & 네임라벨 끄기
        }
    }

    public void Reaction(Vector3 p_pos) // 플레이어가 말을 걸면 리액션
    {
        //0.마우스 포지션과 상호작용 중단
        isEvent = true;
        //1.플레이어 쪽으로 회전
        StartCoroutine(Rotating(p_pos,"대화"));
    }

    //유저를 바라본다(회전)
    IEnumerator Rotating(Vector3 pos,string s)
    {
        if (s == "대화")
        {
            //2.카메라 애니메이션
            MainCam.NpcView(transform);
        }

        //회전
        pos.y = transform.position.y;
        Vector3 dir = (pos - transform.position).normalized;
        float Angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -rotDir;
        }
        while (Angle > 0.0f)
        {
            float delta = 360.0f * Time.deltaTime;
            if (delta > Angle)
            {
                delta = Angle;
            }
            Angle -= delta;
            transform.Rotate(Vector3.up * rotDir * delta, Space.World);

            yield return null;
        }

        if (s == "대화")
        {
            //3. 대화
            bool b = true;
            while (b)
            {
                if (MainCam.Talk_Ready)
                {
                    Connect_Window();
                    b = false;
                }
                yield return null;
            }
            NpcTalk_Window.SetActive(true);
            NpcTalk_Window.GetComponent<NpcTalk_Window>().OnTyping();
        }
    }

    public void Connect_Window() // Talk_Widow와 Npc_Data를 연동
    {
        NpcTalk_Window temp = NpcTalk_Window.GetComponent<NpcTalk_Window>();
        temp.Profile.sprite = Datas.Profile;
        temp.Name.text = Datas.Name;
        temp.SaveText = Datas.Talk;
    }

    //플레이어와 대화 종료 시 원래 바라보고 있던 방향으로 돌아가기
    public void ReturnForward()
    {
        StartCoroutine(Rotating(OrgForward, "원래의 방향을 바라봄"));
    }

    void NameOutLine_false()
    {
        //아웃라인 해제
        for (int i = 0; i < RendererList.Length; ++i)
        {
            RendererList[i].materials = Origin[i];
        }
        //이름 라벨 끄기
        NpcName_Label.SetActive(false);
    }
}
