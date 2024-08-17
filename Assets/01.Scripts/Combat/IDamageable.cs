using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void GetDamage(int value);
    public void GetHeal(int value);
}
