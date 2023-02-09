using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Character_Movement
{
    [Header("-----Player_Movement-----")]
    public bool isEvent = false; // �̺�Ʈ �߻��� �÷��̾� ���� �Ұ�
    public LayerMask TargetMask;

    void Update()
    {
        if (!isEvent)
        {
            //��Ŭ�� - ����
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("Ground")))
                {
                    isJustMove = false;
                    // ���� Skilling �ڷ�ƾ�� �۵����̶��  MoveToPos ���� �Ұ�
                    base.MoveToPos(hit.point);
                }
            }

            //��Ŭ�� - Npc��ȭ or ���� ����
            if (Input.GetMouseButtonDown(0))
            {
                Click_MouseLeftButton();
            }

            //��ų
            if(Input.GetKeyDown(KeyCode.Q))
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

            //������ �ݱ� - ZŰ
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Pickup_Item();
            }
        }
    }

    public void Stop_Movement()
    {
        StopAllCoroutines(); // ���� �ڷ�ƾ�� ���߱�
        GetComponent<Animator>().SetBool("Move", false);
    }

    public void Uncontrol_Player()
    {
        isEvent = true;
    }

    public virtual bool Get_isComboable() { return true; }
    public virtual void Rot_inComboAttak() { }
    public virtual void ComboCheck(bool b) { }
    public virtual void Click_MouseLeftButton() { }
    public virtual void OnSkillRange(int i) { }
    public virtual void Pickup_Item() { }
}