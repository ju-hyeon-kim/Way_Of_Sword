using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Update : Character_Movement
{
    [Header("-----Player_Update-----")]
    public bool ControlPossible = true; // cam������ ���(cam �ִϸ��̼� �۵���)
    public ExSet_ofInterface ExSet;

    void Update()
    {
        if (ControlPossible)
        {
            //��Ŭ��
            if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("Ground")))
                {
                    // ���� Skilling �ڷ�ƾ�� �۵����̶��  MoveToPos ���� �Ұ�
                    base.MoveToPos(hit.point);
                }
            }

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Click_MouseLeftButton();
            }

            //��ų Ű����
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

            //�Ҹ�ǰ Ű����
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

            //������ �ݱ� - ZŰ
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
