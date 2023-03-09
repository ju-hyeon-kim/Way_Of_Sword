using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : Character_Movement
{
    [Header("-----Player_Movement-----")]
    public bool ControlPossible = true; // cam에서도 사용(cam 애니메이션 작동시)
    public LayerMask TargetMask;

    void Update()
    {
        if (ControlPossible)
        {
            //우클릭
            if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("Ground")))
                {
                    // 현재 Skilling 코루틴이 작동중이라면  MoveToPos 실행 불가
                    base.MoveToPos(hit.point);
                }
            }

            //좌클릭 - NpcReaction or 몬스터 공격
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Click_MouseLeftButton();
            }

            //스킬
            if (Input.GetKeyDown(KeyCode.Q))
            {
                OnSkillRange(0);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                OnSkillRange(1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnSkillRange(2);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnSkillRange(3);
            }


            if (Get_isComboable())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Rot_inComboAttak();
                }
            }

            //아이템 줍기 - Z키
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Pickup_Item();
            }
        }
    }

    public void Stop_Movement()
    {
        StopAllCoroutines(); // 무빙 코루틴만 멈추기
        GetComponent<Animator>().SetBool("Move", false);
    }

    public void Uncontrol_Player()
    {
        ControlPossible = false;
    }

    public virtual bool Get_isComboable() { return true; }
    public virtual void Rot_inComboAttak() { }
    public virtual void ComboCheck(bool b) { }
    public virtual void Click_MouseLeftButton() { }
    public virtual void OnSkillRange(int i) { }
    public virtual void Pickup_Item() { }
}