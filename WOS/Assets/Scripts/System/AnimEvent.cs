using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimEvent : MonoBehaviour
{
    public UnityEvent Attack = default;
    public UnityEvent Skill = default;
    public UnityEvent Slide = default;
    public UnityEvent Fire = default;
    public void OnFire()
    {
        Fire?.Invoke();
    }
   public void OnAttack()
    {
        Attack?.Invoke();
    }
    public void OnSkill()
    {
        Skill?.Invoke();
    }
    public void OnSlide()
    {
        Slide?.Invoke();
    }
}
