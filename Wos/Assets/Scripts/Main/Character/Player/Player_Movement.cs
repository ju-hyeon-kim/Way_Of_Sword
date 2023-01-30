using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Character_Movement, IBattle
{
    public DropZone myDropZone;

    public bool isEvent = false; // �̺�Ʈ �߻��� �÷��̾� ���� �Ұ�
    public Transform Weapon_Hand;

    bool isComboable = false;
    int ClickCount = 0;

    public float Ap = 10.0f;
    public LayerMask TargetMask;
    GameObject myEnemy;
    GameObject myNpc;

    bool move_end = false;
    bool rot_end = false;
    bool isNpc = false;

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
                    Move_To_Target = false;
                    base.MoveToPos(hit.point);
                }
            }

            //��Ŭ�� - Npc��ȭ,����
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000.0f, TargetMask))
                {
                    Move_To_Target = true;
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Monster") && !myAnim.GetBool("isAttacking"))
                    {
                        isNpc = false;
                        myEnemy = hit.collider.gameObject;
                        base.MoveToPos(hit.point,() => GetComponent<Animator>().SetTrigger("ComboAttack"));
                    }
                    else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Npc"))
                    {
                        isNpc = true;
                        myNpc = hit.collider.gameObject;
                        base.MoveToPos(hit.point);
                    }
                }
            }

            if(isComboable)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    ++ClickCount;
                    base.MoveToPos(myEnemy.transform.position, null, false, true);
                }
            }

            //������ �ݱ� - ZŰ
            if(Input.GetKeyDown(KeyCode.Z))
            {
                myDropZone.Pickup_Item();
            }
        }
    }
    public override void P_MoveEnd_NpcAction()
    {
        if(isNpc)
        {
            move_end = true;
            NpcEvent();
        }
    }

    public override void P_RotEnd_NpcAction()
    {
        if(isNpc)
        {
            rot_end = true;
            NpcEvent();
        }
    }

    public void NpcEvent()
    {
        if(move_end && rot_end)
        {
            isEvent = true; // �÷��̾��� ���� ����
            myNpc.GetComponent<Npc>().Reaction(gameObject);
            move_end = false;
            rot_end = false;
        }
    }

    public void Stop_Movement()
    {
        StopAllCoroutines(); // ���� �ڷ�ƾ�� ���߱�
        GetComponent<Animator>().SetBool("Move", false);
    }

    public void OnDamage(float dmg)
    {
        if(myAnim.GetBool("isIdle")) // �����߿��� Damage �ִ� �۵��Ұ�, ��, ü���� ����
        {
            myAnim.SetTrigger("Damage");
        }
        
    }
    public void Hit_Target()
    {
        Collider[] list = Physics.OverlapSphere(Weapon_Hand.GetChild(1).position, 1f, 1<<LayerMask.NameToLayer("Monster"));

        foreach (Collider col in list)
        {
            col.GetComponent<Monster>()?.OnDamage(Ap);
        }
    }

    public void ComboCheck(bool v)
    {
        if(v)
        {
            isComboable = true;
            ClickCount = 0;
        }
        else
        {
            isComboable = false;
            if(ClickCount == 0)
            {
                myAnim.SetTrigger("ComboFail");
            }
        }
    }
}
