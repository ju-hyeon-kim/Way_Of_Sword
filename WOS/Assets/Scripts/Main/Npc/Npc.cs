using System.Collections;
using TMPro;
using UnityEngine;

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
            C_Data.NpcName_Label_obj.SetActive(true);
            C_Data.NpcName_Label_obj.GetComponentInChildren<TMP_Text>().text = I_Data.Name;
        }
    }
    private void OnMouseOver() //마우스가 Npc를 가리키고 있는 동안
    {
        C_Data.NpcName_Label_obj.transform.position = Camera.main.WorldToScreenPoint(I_Data.NameLabel_Zone.position);
    }
    private void OnMouseExit() //마우스가 빠져 나갈 때
    {
        Outline_Unactive(); //아웃라인 해제

        //이름 라벨 끄기
        C_Data.NpcName_Label_obj.SetActive(false);
    }
    #endregion

    //유저를 바라본다(회전)
    IEnumerator Rotating(Vector3 pos,bool B) // B = true = 대화시작 // B = false = 대화 끝
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
                    Connect_Window_Individual();

                    b = false;
                }
                yield return null;
            }
            C_Data.NpcTalk_Window_obj.SetActive(true);
            C_Data.NpcTalk_Window_obj.GetComponent<NpcTalk_Window>().Talking(I_Data.Name); //인사
        }
    }

    public void Child_Start_Setting() // 자식 스크립트의 Start()에서 공통으로 사용하는 세팅
    {
        C_Data.NpcName_Label_obj = NpcName_Label.Inst.gameObject;
        C_Data.NpcTalk_Window_obj = NpcTalk_Window.Inst.gameObject;
        C_Data.MainCam = Camera.main.transform.parent.GetComponent<MainCam_Controller>();
        C_Data.OrgForward = I_Data.myForward.position;
    }

    public void Reaction(Vector3 p_pos) // 플레이어가 말을 걸면 리액션
    {
        //1.플레이어 쪽으로 회전
        StartCoroutine(Rotating(p_pos, true));
    }

    public void Connect_Window_Common() // NpcTalk_Widow와 Npc_Data를 연동 (공통적인 요소들을)
    {
        NpcTalk_Window temp = C_Data.NpcTalk_Window_obj.GetComponent<NpcTalk_Window>();
        //이름 적용
        temp.Name.text = I_Data.Name;

        //프로필 적용 = 이름에 따라 해당 프로필만 활성화 나머지는 비활성화
        for (int i = 0; i < temp.Npc_Profiles.Length; i++)
        {
            if (temp.Npc_Profiles[i].name == gameObject.name)
            {
                temp.Npc_Profiles[i].SetActive(true);
            }
            else
            {
                temp.Npc_Profiles[i].SetActive(false);
            }
        }
        //인삿말 적용
        temp.SaveText = I_Data.Greetings;
        //NpcIcon 적용
        temp.Npc_Icon = I_Data.Npc_Icon;
    }

    public virtual void Connect_Window_Individual()
    {
    }

    public void Talk_Start() //대화 시작
    {
        //마우스와 상호작용 해제
        isTalking = true;
        //아웃라인 해제
        Outline_Unactive();
        //이름 라벨 끄기
        C_Data.NpcName_Label_obj.SetActive(false);
    }

    //플레이어와 대화 종료 시 원래 바라보고 있던 방향으로 돌아가기
    public void Talk_End() //대화 끝
    {
        //마우스와 상호작용 작동
        isTalking = false;
        //원래 바라보던 방향으로 회전
        StartCoroutine(Rotating(C_Data.OrgForward, false));
    }


    //버츄얼 함수들
    public virtual void Outline_Active() // 아웃라인 적용
    {
        // 자식이 재정의
    }

    public virtual void Outline_Unactive() // 아웃라인 해제
    {
        // 자식이 재정의
    }

    public virtual void Event_Of_Child()
    {

    }
}
