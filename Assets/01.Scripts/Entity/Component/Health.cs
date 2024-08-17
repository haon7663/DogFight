using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    public event Action OnHpChanged;

    public UnityEvent OnHitEvent;

    public float maxHp;
    public float curHp;
    
    public void GetDamage(int value)
    {
        curHp -= value;
        OnHitEvent?.Invoke();
        OnHpChanged?.Invoke();
    }

    public void GetHeal(int value)
    {
        curHp += value;
        OnHpChanged?.Invoke();
    }
}
