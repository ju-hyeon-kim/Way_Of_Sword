using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimEvent : MonoBehaviour
{
    public UnityEvent Attack = default;
    public UnityEvent<bool> ComboCheck = default;

    public void OnAttack()
    {
        Attack?.Invoke();
    }

    public void ComboCheckStart()
    {
        ComboCheck?.Invoke(true);
    }

    public void ComboCheckEnd()
    {
        ComboCheck?.Invoke(false);
    }

    public void Plus_PageNum()
    {
        transform.parent.GetComponent<SaveLode_Window>().Plus_PageNum();
    }

    public void Minus_PageNum()
    {
        transform.parent.GetComponent<SaveLode_Window>().Minus_PageNum();
    }

    public void BattleStart_UnActive()
    {
        Dont_Destroy_Data.Inst.Manager_Cams.MainCam_Controller.ReturnView();
        gameObject.SetActive(false);
    }
}
