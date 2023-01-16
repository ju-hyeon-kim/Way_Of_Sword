using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    public Npc_IndividualData I_Data;
    public Npc_CommonData C_Data;

    bool isTalking = false; //현재 대화중인 체크하는 bool 값

    #region 마우스 포지션과 상호작용하는 함수
    private void OnMouseEnter() //마우스를 갖다 대었을 때
    {
        if(!isTalking) // 대화중이 아니라면
        {
            //아웃라인 켜기
            Outline_Active();
            //이름 라벨 켜기
            NpcName_Label.Inst.gameObject.SetActive(true);
            NpcName_Label.Inst.GetComponentInChildren<TMP_Text>().text = I_Data.Name;
        }
    }
    private void OnMouseOver() //마우스가 Npc를 가리키고 있는 동안
    {
        NpcName_Label.Inst.transform.position = Camera.main.WorldToScreenPoint(I_Data.NameLabel_Zone.position);
    }
    private void OnMouseExit() //마우스가 빠져 나갈 때
    {
        Outline_Unactive(); //아웃라인 해제

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
            C_Data.MainCam.NpcView(transform);
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
                if (C_Data.MainCam.Talk_Ready)
                {
                    Connect_Window_Common();

                    b = false;
                }
                yield return null;
            }
            C_Data.NpcTalk_Window.gameObject.SetActive(true);
            C_Data.NpcTalk_Window.Talking(this); //인사
        }
    }

    public void Child_Start_Setting() // 자식 스크립트의 Start()에서 공통으로 사용하는 세팅
    {
        C_Data.MainCam = Camera.main.transform.parent.GetComponent<MainCam_Controller>();
        C_Data.OrgForward = I_Data.myForward.position;
    }

    public void Reaction(GameObject Player) // 플레이어가 말을 걸면 리액션
    {
        C_Data.NpcTalk_Window = Player.GetComponent<Player_Main>().NpcTalk_Window;
        //플레이어 쪽으로 회전
        StartCoroutine(Rotating(Player.transform.position, true));
    }

    public void Connect_Window_Common() // NpcTalk_Widow와 Npc_Data를 연동 (공통적인 요소들을)
    {
        //이름 적용
        C_Data.NpcTalk_Window.myTMP_Texts[0].text = I_Data.Name; // Npc의 이름 변경

        //프로필 적용 = 이름에 따라 해당 프로필만 활성화 나머지는 비활성화
        for (int i = 0; i < C_Data.NpcTalk_Window.Npc_Profiles.Length; i++)
        {
            if (C_Data.NpcTalk_Window.Npc_Profiles[i].name == gameObject.name)
            {
                C_Data.NpcTalk_Window.Npc_Profiles[i].SetActive(true);
            }
            else
            {
                C_Data.NpcTalk_Window.Npc_Profiles[i].SetActive(false);
            }
        }
        //인삿말 적용
        C_Data.NpcTalk_Window.SaveText = I_Data.Greetings;
        //NpcIcon 적용
        C_Data.NpcTalk_Window.Npc_Icon = I_Data.Npc_Icon;
    }

    

    public void Talk_Start() //대화 시작
    {
        //마우스와 상호작용 해제
        isTalking = true;
        //아웃라인 해제
        Outline_Unactive();
        //이름 라벨 끄기
        NpcName_Label.Inst.gameObject.SetActive(false);
    }

    //플레이어와 대화 종료 시 원래 바라보고 있던 방향으로 돌아가기
    public void Talk_End() //대화 끝
    {
        //마우스와 상호작용 작동
        isTalking = false;
        //원래 바라보던 방향으로 회전
        StartCoroutine(Rotating(C_Data.OrgForward, false));
    }

    public virtual void Outline_Active() { } // 아웃라인 적용
    public virtual void Outline_Unactive() { } // 아웃라인 해제
    public virtual void Event_Of_Child() { } // 자식마다 다른 이벤트

    public void Buttons_Setting(Proceeding_Quest PQ) //버튼들 연동
    {
        Button0_Set(PQ);
        Button1_Set(PQ);
        Button2_Set();
    }

    public virtual void Button0_Set(Proceeding_Quest PQ) { } // 0번 버튼
    public virtual void Button1_Set(Proceeding_Quest PQ) { } // 1번 버튼
    public void Button2_Set() // 돌아가기 버튼
    {
        C_Data.NpcTalk_Window.Buttons[2].GetComponent<Button>().onClick.AddListener(Button2_OnClick);
        C_Data.NpcTalk_Window.Buttons[2].SetActive(true);
    }

    public void Button2_OnClick() // 돌아가기
    {
        //버튼 비활성화
        for (int i = 0; i < C_Data.NpcTalk_Window.Buttons.Length; i++)
        {
            C_Data.NpcTalk_Window.Buttons[i].SetActive(false);
        }
        C_Data.NpcTalk_Window.gameObject.SetActive(false);
        // 카메라 시점 원래대로
        C_Data.NpcTalk_Window.MainCam.ReturnView();
    }
}
