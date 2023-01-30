using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Character_Movement, IBattle
{
    public DropZone myDropZone;

    public bool isEvent = false; // 이벤트 발생시 플레이어 조작 불가
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
            //우클릭 - 무빙
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 1000.0f, 1 << LayerMask.NameToLayer("Ground")))
                {
                    Move_To_Target = false;
                    base.MoveToPos(hit.point);
                }
            }

            //좌클릭 - Npc대화,공격
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

            //아이템 줍기 - Z키
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
            isEvent = true; // 플레이어의 조작 제한
            myNpc.GetComponent<Npc>().Reaction(gameObject);
            move_end = false;
            rot_end = false;
        }
    }

    public void Stop_Movement()
    {
        StopAllCoroutines(); // 무빙 코루틴만 멈추기
        GetComponent<Animator>().SetBool("Move", false);
    }

    public void OnDamage(float dmg)
    {
        if(myAnim.GetBool("isIdle")) // 공격중에는 Damage 애니 작동불가, 단, 체력은 깎임
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
