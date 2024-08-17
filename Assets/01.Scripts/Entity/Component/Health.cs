using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public event Action OnHpChanged;

    public float maxHp;
    public float curHp;
    
    public void GetDamage(int value)
    {
        curHp -= value;
        OnHpChanged?.Invoke();
    }

    public void GetHeal(int value)
    {
        curHp += value;
        OnHpChanged?.Invoke();
    }
}
