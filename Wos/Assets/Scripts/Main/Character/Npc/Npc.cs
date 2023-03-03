using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [Header("-----Npc-----")]
    public string Name;
    [Multiline]
    public string Greetings; // 인삿말
    public Transform NameLabel_Zone;

    protected NpcTalk_Window NpcTalk_Window;
    MainCam_Controller MainCam;

    bool isTalking = false; //현재 대화중인 체크하는 bool 값
    Vector3 saveForward = Vector3.zero; 

    #region 마우스 포지션과 상호작용하는 함수
    private void OnMouseEnter() //마우스를 갖다 대었을 때
    {
        if (!isTalking) // 대화중이 아니라면
        {
            //아웃라인 켜기
            Outline_SetActive(true);

            //이름 라벨 켜기
            NpcName_Label.Inst.gameObject.SetActive(true);
            NpcName_Label.Inst.GetComponentInChildren<TMP_Text>().text = Name;
        }
    }
    private void OnMouseOver() //마우스가 Npc를 가리키고 있는 동안
    {
        NpcName_Label.Inst.transform.position = Camera.main.WorldToScreenPoint(NameLabel_Zone.position);
    }
    private void OnMouseExit() //마우스가 빠져 나갈 때
    {
        Outline_SetActive(false); //아웃라인 해제

        //이름 라벨 끄기
        NpcName_Label.Inst.gameObject.SetActive(false);
    }
    #endregion

    //유저를 바라본다(회전)
    IEnumerator Rotating(Vector3 pos, bool B) // B = true = 대화시작 // B = false = 대화 끝
    {
        if (B)
        {
            //2.카메라 애니메이션
            MainCam.ChangeView(transform);
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

        if (B)
        {
            //3. 대화
            bool b = true;
            while (b)
            {
                if (MainCam.Talk_Ready)
                {
                    Connect_Window_Common();

                    b = false;
                }
                yield return null;
            }
            NpcTalk_Window.gameObject.SetActive(true);
            NpcTalk_Window.Talking(this); //인사
        }
    }

    public void Child_Start_Setting() // 자식 스크립트의 Start()에서 공통으로 사용하는 세팅
    {
        MainCam = Camera.main.transform.parent.GetComponent<MainCam_Controller>();
    }

    public void Reaction(GameObject Player) // 플레이어가 말을 걸면 리액션
    {
        NpcTalk_Window = Dont_Destroy_Data.Inst.NpcTalk_Window;
        MainCam = Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller;

        //플레이어 쪽으로 회전
        StartCoroutine(Rotating(Player.transform.position, true));

        Child_Reaction(Player);
    }

    public void Connect_Window_Common() // NpcTalk_Widow와 Npc_Data를 연동 (공통적인 요소들을)
    {
        //이름 적용
        NpcTalk_Window.myTMP_Texts[0].text = Name; // Npc의 이름 변경

        //프로필 적용 = 이름에 따라 해당 프로필만 활성화 나머지는 비활성화
        for (int i = 0; i < NpcTalk_Window.Npc_Profiles.Length; i++)
        {
            if (NpcTalk_Window.Npc_Profiles[i].name == gameObject.name)
            {
                NpcTalk_Window.Npc_Profiles[i].SetActive(true);
            }
            else
            {
                NpcTalk_Window.Npc_Profiles[i].SetActive(false);
            }
        }
    }

    public void Talk_Start() //대화 시작
    {
        //원래 바라보던 방향 저장
        saveForward = this.transform.localPosition + this.transform.forward;
        //마우스와 상호작용 해제
        isTalking = true;
        //아웃라인 해제
        Outline_SetActive(false);
        //이름 라벨 끄기
        NpcName_Label.Inst.gameObject.SetActive(false);
    }

    //플레이어와 대화 종료 시 원래 바라보고 있던 방향으로 돌아가기
    public void Talk_End() //대화 끝
    {
        //마우스와 상호작용 작동
        isTalking = false;
        //원래 바라보던 방향으로 회전
        StartCoroutine(Rotating(saveForward, false));
    }

    public virtual void Outline_SetActive(bool b) { } // 아웃라인 적용
    public virtual void Child_Reaction(GameObject Player) { } // 자식마다 다른 리액션

    public void Buttons_Setting() //버튼들 연동
    {
        Button_0and1_Set();
        Button2_Set();
    }

    public virtual void Button_0and1_Set() { } // 퀘스트의 상태 감지

    public void Button2_Set() // 돌아가기 버튼
    {
        NpcTalk_Window.Buttons[2].GetComponent<Button>().onClick.RemoveAllListeners();
        NpcTalk_Window.Buttons[2].GetComponent<Button>().onClick.AddListener(Button2_OnClick);
        NpcTalk_Window.Buttons[2].SetActive(true);
    }

    public void Button2_OnClick() // 돌아가기
    {
        //버튼 비활성화
        for (int i = 0; i < NpcTalk_Window.Buttons.Length; i++)
        {
            NpcTalk_Window.Buttons[i].SetActive(false);
        }
        NpcTalk_Window.gameObject.SetActive(false);
        // 자식따라 달라지는 옵션
        Button2_OnClick_ofChild();
        // 카메라 시점 원래대로
        NpcTalk_Window.MainCam.ReturnView(true);
    }

    public virtual void Button2_OnClick_ofChild() { }
}
