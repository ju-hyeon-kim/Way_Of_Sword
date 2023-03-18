using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : Player_Update
{
    [Header("-----Player_Movement-----")]
    
    public LayerMask TargetMask;
    public ParticleSystem[] RecoverytEffects;
    public RecoveryText_Zone RecoveryText_Zone;

    public void Stop_Movement()
    {
        StopAllCoroutines(); // ���� �ڷ�ƾ�� ���߱�
        GetComponent<Animator>().SetBool("Move", false);
    }

    public void Uncontrol_Player()
    {
        ControlPossible = false;
    }
    public virtual void ComboCheck(bool b) { }
}