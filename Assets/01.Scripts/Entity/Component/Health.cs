using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    public event Action OnHpChanged;

    public UnityEvent OnHitEvent;
    public UnityEvent OnDeadEvent;

    private bool _isInvincible = false;

    public int maxHp;
    public int curHp;

    public void GetDamage(int value)
    {
        if (_isInvincible) return;
        curHp -= value;
        if (curHp <= 0)
            OnDeadEvent?.Invoke();
        else
            OnHitEvent?.Invoke();
        OnHpChanged?.Invoke();
    }

    public void GetHeal(int value)
    {
        curHp += value;
        OnHpChanged?.Invoke();
    }

    public void ModifyInvincible(bool value)
    {
        _isInvincible = value;
    }
}
