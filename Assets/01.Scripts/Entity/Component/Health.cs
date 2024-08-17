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

    public float maxHp;
    public float curHp;

    private void Start()
    {
        OnDeadEvent.AddListener(Ode);
    }

    public void GetDamage(int value)
    {
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

    private void Ode()
    {
        print("DEadae");
    }
}
