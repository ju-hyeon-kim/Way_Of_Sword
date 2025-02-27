using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Update : Character_Movement
{
    [Header("-----Player_Update-----")]
    public bool ControlPossible = true; // cam에서도 사용(cam 애니메이션 작동시)
    public ExSet_ofInterface ExSet;

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

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Click_MouseLeftButton();
            }

            //스킬 키세팅
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

            //소모품 키세팅
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ExSet.Use_ExItem(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ExSet.Use_ExItem(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ExSet.Use_ExItem(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ExSet.Use_ExItem(3);
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

    public virtual void Click_MouseLeftButton() { }
    public virtual void OnSkillRange(int i) { }
    public virtual void Pickup_Item() { }
    public virtual bool Get_isComboable() { return true; }
    public virtual void Rot_inComboAttak() { }
}
