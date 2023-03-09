using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : Character_Movement
{
    [Header("-----Player_Movement-----")]
    public bool ControlPossible = true; // cam������ ���(cam �ִϸ��̼� �۵���)
    public LayerMask TargetMask;

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

            //��Ŭ�� - NpcReaction or ���� ����
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Click_MouseLeftButton();
            }

            //��ų
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
        ControlPossible = false;
    }

    public virtual bool Get_isComboable() { return true; }
    public virtual void Rot_inComboAttak() { }
    public virtual void ComboCheck(bool b) { }
    public virtual void Click_MouseLeftButton() { }
    public virtual void OnSkillRange(int i) { }
    public virtual void Pickup_Item() { }
}