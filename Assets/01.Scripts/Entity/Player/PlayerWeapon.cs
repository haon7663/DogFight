using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private Animator _handAnimator;
    public WeaponSO CurrentWeapon { get; private set; }
    public SquareDamageCaster DamageCasterCompo { get; private set; } 

    private int _comboCounter = 0;
    private float _lastAttackTime = 0;
    private float _comboInitTime = 0.4f;
    private float _attackDelay = 0.1f;
    private readonly int _comboCounterHash = Animator.StringToHash("ComboCounter");

    public void Attack()
    {
        if (_lastAttackTime + _attackDelay < Time.time) return;
        if (_lastAttackTime + _comboInitTime < Time.time || _comboCounter > 2)
            _comboCounter = 0;
        _handAnimator.SetInteger(_comboCounterHash, _comboCounter);
        _comboCounter++;
        DamageCasterCompo.DamageCast(_comboCounter, CurrentWeapon.attackRange[_comboCounter]);
        _lastAttackTime = Time.time;
    }
}
