using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct CharacterStat
{
    [SerializeField] float hp;
    [SerializeField] float maxhp;
    [SerializeField] float mp;
    [SerializeField] float maxmp;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] float ap;
    [SerializeField] float attackRange;
    [SerializeField] float attackSpeed;

    public UnityAction<float> changeHP;
    public UnityAction<float> changeMP;
    public float HP
    {
        get => hp;
        set
        {
            hp = Mathf.Clamp(value, 0.0f, maxhp);
            changeHP?.Invoke(hp / maxhp);
        }
    }
    public float MP
    {
        get => mp;
        set
        {
            mp = Mathf.Clamp(value, 0.0f, maxmp);
            changeMP?.Invoke(mp / maxmp);
        }
    }
    public float MoveSpeed
    {
        get => moveSpeed;
    }
    public float RotSpeed
    {
        get => rotSpeed;
    }
    public float AttackRange
    {
        get => attackRange;
    }
    public float AP
    {
        get => ap;
    }

    public float AttackSpeed
    {
        get => attackSpeed;
    }
}
    
