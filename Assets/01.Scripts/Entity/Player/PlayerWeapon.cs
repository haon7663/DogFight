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
    private float _comboInitTime = 1f;
    private float _comboInitTimer = 0f;
    private float _attackDelay = 0.1f;
    private bool _isAttacking = false;
    private readonly int _comboCounterHash = Animator.StringToHash("ComboCounter");
    private readonly int _attackBoolHash = Animator.StringToHash("Attack");

    private void Update()
    {
        if(_isAttacking)
        {
            _comboInitTimer += Time.deltaTime;
            if(_comboInitTimer > _comboInitTime)
            {
                _handAnimator.SetBool(_attackBoolHash, false);
                _comboCounter = 0;
                _comboInitTimer = 0;
                _isAttacking = false;
            }
        }
    }

    public void Attack()
    {
        if (_lastAttackTime + _attackDelay > Time.time) return;
        if (_lastAttackTime + _comboInitTime < Time.time || _comboCounter > 2)
            _comboCounter = 0;
        _comboInitTimer = 0;
        _isAttacking = true;
        _handAnimator.SetBool(_attackBoolHash, true);
        _handAnimator.SetInteger(_comboCounterHash, _comboCounter);
        _comboCounter++;
        //DamageCasterCompo.DamageCast(_comboCounter, CurrentWeapon.attackRange[_comboCounter]); // 콤보에 따라 다른 공격 범위
        DamageCasterCompo.DamageCast(_comboCounter, CurrentWeapon.attackRange[0]);
        _lastAttackTime = Time.time;
    }
}
